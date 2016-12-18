using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSAM.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CountryCode { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public int Age => DateOfBirth.HasValue ? Convert.ToInt32(DateTime.Today.Subtract(DateOfBirth.Value).TotalDays / 365.2425D) : 0;
    }
}
