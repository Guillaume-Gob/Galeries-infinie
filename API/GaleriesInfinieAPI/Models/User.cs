using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace GaleriesInfinieAPI.Models
{
    public class User : IdentityUser
    {
        [JsonIgnore]
        public virtual List<Galerie>? Galeries { get; set; }


    }
}
