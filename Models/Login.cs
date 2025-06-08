using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Employeemanage.Models
{
    public class Login
    {
        [Key]
        public int EmployeeId { get; set; }



        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }



        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }



        [Required(ErrorMessage = "Designation is required")]
        [StringLength(100)]
        public string Designation { get; set; }



        [Required(ErrorMessage = "Employment Type is required")]
        public string EmploymentType { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }



        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Emergency Contact is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Emergency Contact must be 10 digits")]
        public string EmergencyContact { get; set; }



        public string ProfilePicture { get; set; } 



        [Required(ErrorMessage = "Skills field is required")]
        public string Skills { get; set; } 


        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }


        [Required(ErrorMessage = "Work Experience is required")]
        [Range(0, 50, ErrorMessage = "Work Experience must be between 0 and 50 years")]
        public int WorkExperience { get; set; }


        [DefaultValue(0)]
        public int status { get; set; }


        [DefaultValue("User")]
        public string Role { get; set; }

    }
}
