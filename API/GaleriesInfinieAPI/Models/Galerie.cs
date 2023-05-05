using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GaleriesInfinieAPI.Models
{
    public class Galerie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? FileName { get; set; } 

        public string? MimeType { get; set; }

        
        public bool Private { get; set; } = true;

        [JsonIgnore]
        public virtual List<User>? Propriétaires { get; set; }

        [JsonIgnore]
        public virtual List<Photo>? Photos { get; set; }









    }
}
