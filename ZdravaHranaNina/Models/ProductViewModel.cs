using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZdravaHranaNinaEntities;

namespace ZdravaHranaNina.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]

        public DateTime BestBefore { get; set; }
        [Required]

        public DateTime DateManifactured { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Manifacturer { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Discription { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public string Shipping { get; set; }

        public string PhotoURL { get; set; }

        public int SoldItems { get; set; }

        public double Rating { get; set; }

        public DateTime DateAdded { get; set; }

        public string CountryOfOrigin { get; set; }

        public bool Popularity { get; set; }

        public bool ByWeight { get; set; }

        public bool ByPeace { get; set; }

        [StringLength(100)]
        public string CategoryNameDTO { get; set; }
    }
}
