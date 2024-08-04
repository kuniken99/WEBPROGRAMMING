using System.ComponentModel.DataAnnotations;

namespace INFT3050.Models
{
    public class CustomerProfileViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d]+$", ErrorMessage = "The username must contain at least one letter.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your fullname.")]
        [StringLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^[\d+]+$", ErrorMessage = "The phone number must contain only digits and/or the '+' sign.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(255)]
        public string Address { get; set; } = string.Empty;

    }
}
