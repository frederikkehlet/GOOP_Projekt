/*
The person class is intended as a superclass, from which the TennisPlayer and Referee class inherit directly. The class is set to abstract, because the program will not be using Person objects.

The class has a method that calculates the age, and the method is called inside the constructor. The method requires the DateOfBirth property, therefore the DateOfBirth property is set before the Age property
in the constructor.
*/
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
        public int Age { get; }
        public sex Gender { get; set; }
       
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
            string fullName = String.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            return String.Format("Name: {0} \nDate of birth: {1}\nAge: {2}\nNationality: {3}\nGender: {4}\n",
                fullName, DateOfBirth.ToShortDateString(), Age, Nationality, Gender);
        }

        private int calcAge()
        {
            var currentYear = DateTime.Parse(Convert.ToString(DateTime.Today)).Year;
            var birthYear = DateTime.Parse(Convert.ToString(DateOfBirth)).Year;
            var age = currentYear - birthYear;
            if (DateTime.Today < DateOfBirth.AddYears(age)) age--;
            return age;
        }
    }
}
