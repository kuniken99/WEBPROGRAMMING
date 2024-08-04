using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace INFT3050.Models
{
    public class User : IdentityUser
    {
        /*public int StaffID { get; set; } //primary key

        [Required(ErrorMessage = "Please enter the account type.")]
        public int? AccountType { get; set; } //Determines the account type: 1 = admin, 2 = employee, 3 = cutomer

        [Required(ErrorMessage = "Please enter a name.")]*/
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    
    /*
    [Required(ErrorMessage = "Please enter a username.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a password.")]
    public string Password { get; set; } = string.Empty;*/


    }
}
