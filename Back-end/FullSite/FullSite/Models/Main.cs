using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSite.Models
{
    public class Main
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(450)]
        public string Profile{ get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Substring { get; set; }

        [Column(TypeName ="ntext")]
        public string About { get; set; }
    }
}
