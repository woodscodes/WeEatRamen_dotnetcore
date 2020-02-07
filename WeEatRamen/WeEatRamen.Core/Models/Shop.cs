using System;
using System.Collections.Generic;
using System.Text;
using WeEatRamen.Core.Enums;

namespace WeEatRamen.Core.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public SoupBase Soup { get; set; }
        public string ImgUrl { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
