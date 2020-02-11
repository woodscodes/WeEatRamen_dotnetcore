using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WeEatRamen.Core.Enums;

namespace WeEatRamen.Core.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
        public SoupBase Soup { get; set; }
        public string ImgUrl { get; set; }
        
        [Range(0, 5, ErrorMessage ="Ratings must be between 0 and 5")]
        public int Rating { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
