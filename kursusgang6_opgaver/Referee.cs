using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    public class Referee : Person
    {
        public DateTime LicenseAquired { get; set; }
        public DateTime LicenseRenewed { get; set; }

        public Referee(string firstName, string middleName, string lastName, string dateOfBirth,
            sex gender, string nationality, string licenseAquired, string licenseRenewed): 
            base(firstName,middleName,lastName,dateOfBirth,nationality,gender)
        {
            LicenseAquired = DateTime.ParseExact(licenseAquired, "yyyy-MM-dd", null);
            LicenseRenewed = DateTime.ParseExact(licenseRenewed, "yyyy-MM-dd", null);
        }

        public override string ToString()
        {
            return String.Format("First name: {0}\nLast name: {1}\nDate of birth: {2}\n" +
                "Age: {3}\nGender: {4}\nLicense aquired: {5}\nLicense renewed: {6}\n", FirstName, LastName,
                DateOfBirth.ToShortDateString(), Age, Gender, LicenseAquired.ToShortDateString(), LicenseRenewed.ToShortDateString());
        }
    }
}
