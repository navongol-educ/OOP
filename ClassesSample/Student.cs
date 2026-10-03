using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesSample
{
    // ---------- Student ----------
    public class Student
    {
        public static int TotalCreated { get; private set; }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Student(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TotalCreated++;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {FirstName} {LastName}";
        }
    }
}
