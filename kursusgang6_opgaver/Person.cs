using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tennis_tournament
{
    public enum sex { female, male }

    public abstract class Person // the program does not use Person objects, therefore the class is abstract
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public sex Gender { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="middleName">Middle name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="birthDate">Birthdate in yyyy-MM-dd format</param>
        /// <param name="nationality">Nationality</param>
        /// <param name="gender">Gender</param>
        // Constructor 
        public Person(string firstName, string middleName, string lastName, string birthDate,
            string nationality, sex gender)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = DateTime.ParseExact(birthDate, "yyyy-MM-dd", null);
            Age = calcAge();
            Nationality = nationality;
            Gender = gender;
        }

        public override string ToString()
        {
            string Name = String.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            return String.Format("Name: {0} \nDate of birth: {1}\nAge: {2}\nNationality: {3}\nGender: {4}\n",
                Name, DateOfBirth.ToShortDateString(), Age, Nationality, Gender);
        }

        private int calcAge()
        {
            // get current date
            var now = DateTime.Today;

            // get year only from current date
            var currentYear = DateTime.Parse(Convert.ToString(now)).Year;

            // get year only from birthdate
            var birthYear = DateTime.Parse(Convert.ToString(DateOfBirth)).Year;

            // calculate difference in years
            var age = currentYear - birthYear;

            // check if birthday has passed within current year
            if (now < DateOfBirth.AddYears(age)) age--;
            return age;
        }
    }
}
