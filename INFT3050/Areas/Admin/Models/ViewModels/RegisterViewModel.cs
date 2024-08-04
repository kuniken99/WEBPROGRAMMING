using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace INFT3050.Areas.Admin.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Please enter your fullname.")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Za-z])[A-Za-z\d]+$", ErrorMessage = "The username must contain at least one letter.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a phone number.")]
        [StringLength(255), MinLength(8)]
        [RegularExpression(@"^[\d+]+$", ErrorMessage = "The phone number must contain only digits and/or the '+' sign.")]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
