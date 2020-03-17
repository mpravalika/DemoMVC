using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class Validationscls
    {
        string firstname;
        string lastname;
        double salary;
        string pancard;
        string password;
        string confirmpwd;
        string phone;
        string email;
        DateTime doj;
        [Required(ErrorMessage ="First Name is Must")]
        [StringLength(maximumLength:15,ErrorMessage ="Max length is 15 only")]
        public string Firstname { get => firstname; set => firstname = value; }
        [Required(ErrorMessage ="Last Name is Must")]
        public string Lastname { get => lastname; set => lastname = value; }
        [Required(ErrorMessage = "*")]
        [Range(10000,200000,ErrorMessage ="sal must be between 10000 to 200000")]
        public double Salary { get => salary; set => salary = value; }
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[A-Z]{5}[0-9]{4}[A-Z]$",ErrorMessage ="Invalid Pan")]
        public string Pancard { get => pancard; set => pancard = value; }
        [Required(ErrorMessage = "*")]
        public string Password { get => password; set => password = value; }
        [Required(ErrorMessage = "*")]
        [Compare("Password",ErrorMessage ="Password Mismatch")]
        [DataType(DataType.Password)]
        public string Confirmpwd { get => confirmpwd; set => confirmpwd = value; }
        [Phone(ErrorMessage ="Not a valid phone number")]
        [MinLength(10,ErrorMessage ="10 digits only")]
        [MaxLength(10,ErrorMessage ="10 digits only")]
        public string Phone { get => phone; set => phone = value; }
        [EmailAddress(ErrorMessage ="Not a valid emailid")]
        public string Email { get => email; set => email = value; }
        //[CustomAge(ErrorMessage = "Age must be b/w 21 to 58")]
        [CustomDOJ(ErrorMessage ="date cannot be > today's date")]
        public DateTime Doj { get => doj; set => doj = value; }
    }
}