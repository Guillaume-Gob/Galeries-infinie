using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaleriesInfinieAPI.Data;
using GaleriesInfinieAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace GaleriesInfinieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaleriesController : ControllerBase
    {
        private readonly GaleriesInfinieAPIContext _context;
       private readonly UserManager<User> _userManager;

        public GaleriesController(GaleriesInfinieAPIContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Galeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetAllPublic()
        {
          if (_context.Galerie == null)
          {
              return NotFound(new {Message = "Aucun Contexte Update-Database :) " });
          }
          List<Galerie> reponse = new List<Galerie>();
           reponse = await _context.Galerie.Where(g => g.Private == false).ToListAsync();
            
            return reponse;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetMyGaleries()
        {
           
            if (_context.Galerie == null)
            {
                return NotFound(new { Message = "Aucun Contexte Update-Database :) " });
            }
            
              User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));


            
            if (user != null)
            {
                List<Galerie> reponse = user.Galeries;

                return reponse;

            
            }
            else { return Unauthorized("Il n'y a pas de user connecter"); }
        }

        

        // PUT: api/Galeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalerie(int id, Galerie galerie)
        {
            if (id != galerie.Id)
            {
                return BadRequest();
            }

            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user.Galeries.Where(g => g.Id == id).First() == null)
            { 
                  return Unauthorized(new {Message = "l'utilisateur n'a pas les droits de modification sur cette galerie" });
            }
            

            Galerie UpdateGalerie = await _context.Galerie.FirstAsync(g => g.Id == id);
            if (UpdateGalerie == null) {
                return NotFound();
            }
            UpdateGalerie.Private = galerie.Private;
            UpdateGalerie.Name = galerie.Name;
            
            
            

            //_context.Entry(galerie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalerieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok( new { Message = "Galerie Modifier! " });
        }
        [HttpPost("{idGalerie}")]
        public async Task<IActionResult> AddUserToGalerie(string Username, int idGalerie) {
            if (_context.Galerie == null)
            {
                return Problem("Entity set 'GaleriesInfinieAPIContext.Galerie'  is null.");
            }
           
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return BadRequest("Aucun Utilisateur Connecter");
            }

            if (user.Galeries.Where(g => g.Id == idGalerie).First() == null)
            {
                return Unauthorized(new { Message = "l'utilisateur n'a pas les droits de modifications sur cette galerie" });
            }
            User? utilisateurAjouter = await _userManager.Users.FirstAsync(u => u.UserName.Equals(Username));
            if (utilisateurAjouter == null)
            {
                return BadRequest("Aucun Utilisateur Portant ce nom");
            }

            Galerie UpdateGalerie = await _context.Galerie.FirstAsync(g => g.Id == idGalerie);
            UpdateGalerie.Propriétaires.Add(utilisateurAjouter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalerieExists(idGalerie))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Message = "Utilisateur ajouer a la liste de Propriétaires! " });
        }

        // POST: api/Galeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galerie>> PostGalerie(Galerie galerie)
        {
          if (_context.Galerie == null)
          {
              return Problem("Entity set 'GaleriesInfinieAPIContext.Galerie'  is null.");
          }
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) 
            {
                return Unauthorized("Il n'y a pas de user connecter");
            }
            galerie.Propriétaires = new List<User>();
            galerie.Propriétaires.Add(user);
            _context.Galerie.Add(galerie);
            await _context.SaveChangesAsync();

            return Ok(new {Message = "Galerie Créé!" });
        }

        // DELETE: api/Galeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalerie(int id)
        {
            if (_context.Galerie == null)
            {
                return NotFound();
            }

            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user.Galeries.Where(g => g.Id == id).First() == null)
            {
                return Unauthorized(new { Message = "l'utilisateur n'a pas les droits de modifications sur cette galerie" });
            }


            var galerie = await _context.Galerie.FindAsync(id);
            if (galerie == null)
            {
                return NotFound();
            }

            _context.Galerie.Remove(galerie);
            await _context.SaveChangesAsync();

            return Ok( new {Message = "La galerie a été supprimer" });
        }

        private bool GalerieExists(int id)
        {
            return (_context.Galerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
