using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    public class Referee
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public sex Gender { get; set; }
        public DateTime LicenseAquired { get; set; }
        public DateTime LicenseRenewed { get; set; }

        public Referee(string firstName, string middleName, string lastName, string dateOfBirth, 
            sex gender, string licenseAquired, string licenseRenewed)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = DateTime.ParseExact(dateOfBirth, "yyyy-MM-dd", null);
            Age = calcAge(); 
            Gender = gender;
            LicenseAquired = DateTime.ParseExact(licenseAquired, "yyyy-MM-dd", null);
            LicenseRenewed = DateTime.ParseExact(licenseRenewed, "yyyy-MM-dd", null);
        }

        public override string ToString()
        {
            return String.Format("First name: {0}\nLast name: {1}\nDate of birth: {2}\n" +
                "Age: {3}\nGender: {4}\nLicense aquired: {5}\nLicense renewed: {6}\n", FirstName, LastName, 
                DateOfBirth.ToShortDateString(),Age,Gender, LicenseAquired.ToShortDateString(),LicenseRenewed.ToShortDateString());
        }

        private int calcAge()
        {
            // get current date
            var now = DateTime.Today;

            // get year only from current date
            var currentYear = DateTime.Parse(Convert.ToString(now)).Year;

            // get year only from birthdate
            var birthYear = DateTime.Parse(Convert.ToString(DateOfBirth)).Year;

            // calculate "rough" age
            var age = currentYear - birthYear;

            // check if birthday has passed within current year
            if (now < DateOfBirth.AddYears(age)) age--;
            return age;
        }
    }
}
