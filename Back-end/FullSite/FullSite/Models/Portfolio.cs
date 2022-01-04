using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullSite.Models
{
    public class Portfolio
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Column(TypeName ="ntext")]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
