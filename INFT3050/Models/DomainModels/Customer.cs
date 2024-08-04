using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace INFT3050.Models
{
    public class Customer { 
        //initialize navigation property collection for one-to-many relationship CustomerOrder
        public Customer() => Orders = new HashSet<Order>();
        public int CustomerID { get; set; } //primary key
        public int AccountType { get; set; } = 3; //Determines the account type: 1 = admin, 2 = employee, 3 = cutomer 
                                                  //Account type customer automatically set when created

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a mobile number.")]
        public string MobileNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; } = string.Empty;
        public ICollection<Order> Orders { get; set; } //navigation property

    }
}
