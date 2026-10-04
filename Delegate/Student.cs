using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Student
    {
        private int _grade;
        public string Name { get; set; }
        public string StudentClass { get; set; }

        // Auto-implemented property with default value
        public int Grade { get; set; } = 0;

        // Property with validation in the setter
        //public int Grade
        //{
        //    get { return _grade; }
        //    // get => _grade;
        //    set
        //    {
        //        if (value < 0 || value > 100)
        //        {
        //            throw new ArgumentOutOfRangeException("Grade must be between 0 and 100.");
        //        }
        //        _grade = value;
        //    }
        //}

        //public int Grade
        //{
        //    get => _grade;
        //    set => _grade = (value >= 0 && value <= 100) ? value : throw new ArgumentOutOfRangeException("Grade must be between 0 and 100.");
        //}



        public override string ToString()
        {
            return $"Name: {Name} Class: {StudentClass} Grade: {Grade}";
        }
    }

}
