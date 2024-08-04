using System;
using System.ComponentModel.DataAnnotations;

namespace INFT3050.Models
{
    public class Brand
    {

        public int BrandId { get; set; } //primary key

        [Required(ErrorMessage = "Please the name of the brand.")]
        public string BrandName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;



    }
}
