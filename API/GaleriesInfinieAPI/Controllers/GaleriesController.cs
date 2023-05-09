using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GaleriesInfinieAPI.Data;
using GaleriesInfinieAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

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
                return NotFound(new { Message = "Aucun Contexte Update-Database :) " });
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
                return Unauthorized(new { Message = "l'utilisateur n'a pas les droits de modification sur cette galerie" });
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

            return Ok(new { Message = "Galerie Modifier! " });
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> ChangerCouverture(int Id) {
            if (_context.Galerie == null)
            {
                return Problem("Entity set 'GaleriesInfinieAPIContext.Galerie'  is null.");
            }
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Galerie? galerie = await _context.Galerie.Where(g => g.Id == Id).FirstOrDefaultAsync();
                    if (galerie == null)
                    { return BadRequest("La galerie n'existe pas"); }
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + galerie.FileName);
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + galerie.FileName);
                    Image image = Image.Load(file.OpenReadStream());
                    galerie.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    galerie.MimeType = file.ContentType;

                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + galerie.FileName);
                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }

                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + galerie.FileName);
                }
            }
            catch (Exception)
            {
                throw;
            }
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Galerie Créé!" });


        }
        [HttpPost("{GalerieId}")]
        public async Task<IActionResult> AddPhotoGalerie(int GalerieId)
        {
            if (_context.photo == null)
            {
                return Problem("Entity set 'GaleriesInfinieAPIContext.Photo'  is null.");
            }
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Galerie? galerie = await _context.Galerie.Where(g => g.Id == GalerieId).FirstOrDefaultAsync();
                    if (galerie == null)
                    { return BadRequest("La galerie n'existe pas"); }
                    Image image = Image.Load(file.OpenReadStream());
                    Photo AddedPhoto = new Photo() { FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName), MimeType = file.ContentType, GalerieId = galerie.Id, Galerie = galerie };
                    await _context.photo.AddAsync(AddedPhoto);
                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + AddedPhoto.FileName);
                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }

                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/miniature/" + AddedPhoto.FileName);
                }
                else
                {
                    return BadRequest("Pas de fichier");
                }
            }
            catch (Exception)
            {
                throw;
            }
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Photo Ajoutée!" });
        }

        [HttpDelete("{PhotoId}")]
        public async Task<IActionResult> DeletePhoto(int PhotoId) {
            if (_context.Galerie == null)
            {
                return NotFound();
            }
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) 
            {
                return Unauthorized();
            }
            Photo? photo = await _context.photo.FindAsync(PhotoId);
            if (photo == null)
            {
                return BadRequest();
            }

            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);
            _context.photo.Remove(photo);
            await _context.SaveChangesAsync();
            return Ok(new {Message = "La Photo a bien été supprimer"});


        }
                
                

        [HttpGet("{GalerieId}")]
        public async Task<ActionResult<IEnumerable<Photo>>> getPhotos(int GalerieId) {
            if (_context.photo == null)
            {
                return NotFound();
            }

            Galerie? galerie = await _context.Galerie.FindAsync(GalerieId);
            if (galerie == null)
            { 
            return BadRequest();
            }
            if(galerie.Photos == null || galerie.Photos.Count == 0 )
            {
                return Ok(new { Message = "La galerie ne contient pas de Photos" });
            }

            return galerie.Photos;
        }
        [HttpGet("{size}/{PhotoId}")]
        public async Task<IActionResult> GetImagePhoto(int PhotoId, string size) {
            if (_context.photo == null)
            {
                return NotFound();
            }

            Photo? photo = await _context.photo.FindAsync(PhotoId);
            if (photo == null || photo.FileName == null || photo.MimeType == null)
            {
                return NotFound(new { Message = "La photo n'existe pas ou n'a pas de photo" });
            }

            if (!Regex.Match(size, "original|miniature").Success)
            {

                return BadRequest(new { Message = "La taille demande n'existe pas" });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" +photo.FileName);
            return File(bytes, photo.MimeType);

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
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Galerie>> PostGalerie()
        {
            Galerie galerie = new Galerie();
          if (_context.Galerie == null)
          {
              return Problem("Entity set 'GaleriesInfinieAPIContext.Galerie'  is null.");
          }
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null) 
            {
                return Unauthorized("Il n'y a pas de user connecter");
            }
            string? NomGalerie = Request.Form["NomGalerie"];
            string? IspublicString = Request.Form["isPublic"];
            if (NomGalerie == null || IspublicString == null)
            {

                return BadRequest(new { Message = "Un ou plusieurs champs vide" });
            }

            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());
                    galerie.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    galerie.MimeType = file.ContentType;

                    image.Save(Directory.GetCurrentDirectory() + "/images/original/" + galerie.FileName);
                    image.Mutate(i => i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }

                    }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/miniature/"+ galerie.FileName);

                    bool IsPrivate = bool.Parse(IspublicString);
                  
                        galerie.Private = IsPrivate;
                    galerie.Name = NomGalerie;
                    
                }
                else
                {
                    return NotFound(new { Message = " Aucune image n'a été envoyé" });
                }

            }
            catch (Exception)
            {
                throw;
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
         

            Galerie? galerie = await _context.Galerie.FindAsync(id);
           
            if (galerie == null)
            {
                return NotFound();
            }
            if (galerie.Photos.Count > 0) 
            {
                foreach (Photo photo in galerie.Photos) {

                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + photo.FileName);
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + photo.FileName);

                   _context.photo.Remove(photo);
                }
            }

            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/miniature/" + galerie.FileName);
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/original/" + galerie.FileName);


            _context.Galerie.Remove(galerie);
            await _context.SaveChangesAsync();

            return Ok( new {Message = "La galerie et ses photos ont été supprimé" });
        }
        [HttpGet("{size}/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPhotoGalerie(string size, int id) 
        {
            if (_context.Galerie == null)
            {
                return NotFound();
            }

            Galerie? galerie = await _context.Galerie.FindAsync(id);
            if (galerie == null || galerie.FileName == null || galerie.MimeType == null)
            {
                return NotFound(new { Message = "La galerie n'existe pas ou n'a pas de photo" });
            }

            if(!Regex.Match(size, "original|miniature").Success){

                return BadRequest(new { Message = "La taille demande n'existe pas" });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" + galerie.FileName);
            return File(bytes, galerie.MimeType);

        }


        private bool GalerieExists(int id)
        {
            return (_context.Galerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
