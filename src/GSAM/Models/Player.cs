using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Player
    {
        [DisplayName("Player ID")]
        public int PlayerID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter player's first name.")]
        [DisplayName("First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter player's last name.")]
        [DisplayName("Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please specify player's gender.")]
        public bool Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select player's country.")]
        [DisplayName("Country")]
        [StringLength(3)]
        public string CountryCode { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public int Age => DateOfBirth.HasValue ? Convert.ToInt32(DateTime.Today.Subtract(DateOfBirth.Value).TotalDays / 365.2425D) : 0;
    }
}
