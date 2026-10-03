using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesSample
{
    // ---------- SchoolClass ----------
    public class SchoolClass
    {
        public const int MAX_STUDENTS = 30;

        public string ClassName { get; }
        public int StudentsCount { get; private set; }

        private Student[] students;

        public SchoolClass(string className)
        {
            ClassName = className;
            students = new Student[MAX_STUDENTS];
            StudentsCount = 0;
        }

        public bool ContainsId(string id)
        {
            for (int i = 0; i < StudentsCount; i++)
            {
                if (students[i].Id == id)
                    return true;
            }
            return false;
        }

        public bool AddStudent(Student s)
        {
            if (StudentsCount >= MAX_STUDENTS)
                return false;

            if (ContainsId(s.Id))
                return false;

            students[StudentsCount++] = s;
            return true;
        }

        public void PrintAllStudents()
        {
            Console.WriteLine($"\nClass: {ClassName}");
            Console.WriteLine($"Students: {StudentsCount}/{MAX_STUDENTS}");

            if (StudentsCount == 0)
            {
                Console.WriteLine("(No students)");
                return;
            }

            for (int i = 0; i < StudentsCount; i++)
                Console.WriteLine($"{i + 1}. {students[i]}");
        }
    }
}
