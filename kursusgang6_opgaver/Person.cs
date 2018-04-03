using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursusgang6_opgaver
{
    class Person
    {
        public string Name { get; set; }
        public Person Spouse { get; set; }

        public Person(string name, Person spouse)
        {
            Name = name;
            Spouse = spouse;
        }

        public override string ToString()
        {
            string rv = "Name: " + Name + " Spouse: " + Spouse.Name;
            if (rv != null)
            {
                return rv;
            }
            else
            {
                return "";
            }
        }
    }
}
