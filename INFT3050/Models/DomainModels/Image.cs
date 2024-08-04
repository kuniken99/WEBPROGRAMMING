using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INFT3050.Models
{
    public class Image
    {
        public int ImageID { get; set; } //primary key
        public int ItemID { get; set; } //foreign key need to do this for entity relationships
        //for one to many (ItemImages) must add a navigation property then add hashset in the customers table
        public Item Item { get; set; } = null!; //navigation property
        public string ImagePath { get; set; } = string.Empty;

        
    }
}
