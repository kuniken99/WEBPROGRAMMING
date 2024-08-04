using System.ComponentModel.DataAnnotations;

namespace INFT3050.Areas.Admin.Models
{
    public class EditCustomerViewModel
    {
        [Required(ErrorMessage = "Please enter your fullname.")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d]+$", ErrorMessage = "The username must contain at least one letter.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^[\d+]+$", ErrorMessage = "The phone number must contain only digits and/or the '+' sign.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string CustomerID { get; set; } = string.Empty;
    }
}
