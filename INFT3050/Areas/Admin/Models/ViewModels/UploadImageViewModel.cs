using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using INFT3050.Models;

namespace INFT3050.Areas.Admin.Models
{
    public class UploadImageViewModel
    {
        //public List<Item> Items { get; set; }
       // [NotMapped]
        //public Item ItemInstance { get; set; }
        public int ImageId { get; set; }
        public int ItemId { get; set; }

        
        [Required(ErrorMessage = "Please choose an image.")]
        public IFormFile? ImageFile { get; set; } = null;
    }
}
