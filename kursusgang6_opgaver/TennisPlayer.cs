using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    public enum sex { female, male }

    class TennisPlayer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public sex Gender { get; set; }

        // Constructor til folk uden mellemnavne
        public TennisPlayer(string firstName, string lastName, string birthDate,
            string nationality, sex gender)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = DateTime.ParseExact(birthDate, "yyyy-MM-dd", null);
            Nationality = nationality;
            Gender = gender;
        }

        // Constructor til folk med mellemnavne
        public TennisPlayer(string firstName, string middleName, string lastName, string birthDate,
            string nationality, sex gender)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = DateTime.ParseExact(birthDate, "yyyy-MM-dd", null);
            Nationality = nationality;
            Gender = gender;
        }

        public override string ToString()
        {
            string Name = String.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            string age = Convert.ToString(Age(DateOfBirth));
            return String.Format("Name: {0} \nDate of birth: {1}\nAge: {2}\nNationality: {3}\nGender: {4}\n",
                Name,DateOfBirth.ToShortDateString(),age, Nationality,Gender);
        }

        public int Age(DateTime dateOfBirth)
        {
            // get current date
            var now = DateTime.Today;

            // get year only from current date
            var currentYear = DateTime.Parse(Convert.ToString(now)).Year;

            // get year only from birthdate
            var birthYear = DateTime.Parse(Convert.ToString(dateOfBirth)).Year;

            // calculate "rough" age
            var age = currentYear - birthYear; 
            
            // check if birthday has passed within current year
            if (now < dateOfBirth.AddYears(age)) age--;
            return age;
        }
    }
}
