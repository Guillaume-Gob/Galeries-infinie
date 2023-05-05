using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GaleriesInfinieAPI.Models
{
    public class Photo
    {

        [Required]
        public int PhotoId { get; set; }


        public string? FileName { get; set; }

        public string? MimeType { get; set; }

        [ForeignKey("Galerie")]
        [Required]
        public int GalerieId { get; set; }

        [JsonIgnore]
        public virtual Galerie? Galerie { get; set; }


    }
}
