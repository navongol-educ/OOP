using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesSample
{

    //OOP_TwoClasses_Students
    // ---------- Program ----------
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name for Class #1: ");
            string className1 = Console.ReadLine();

            Console.Write("Enter name for Class #2: ");
            string className2 = Console.ReadLine();

            SchoolClass class1 = new SchoolClass(className1);
            SchoolClass class2 = new SchoolClass(className2);

            FillClassWithStudents(class1);
            FillClassWithStudents(class2);

            Console.WriteLine("\n==================== RESULTS ====================");
            class1.PrintAllStudents();
            class2.PrintAllStudents();

            Console.WriteLine($"\nTotal students created in program: {Student.TotalCreated}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void FillClassWithStudents(SchoolClass c)
        {
            Console.WriteLine($"\n--- Add students to class: {c.ClassName} ---");

            while (c.StudentsCount < SchoolClass.MAX_STUDENTS)
            {
                Console.WriteLine($"\nAdd student #{c.StudentsCount + 1} (type X as ID to stop)");

                string id = ReadValidUniqueIdOrStop(c);
                if (id == null)
                    return; // user stopped with X

                Console.Write("First name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                // Create student ONLY after ID validation
                Student s = new Student(id, firstName, lastName);

                if (!c.AddStudent(s))
                {
                    Console.WriteLine("Could not add student (class full or duplicate).");
                    break;
                }

                Console.Write("Add another student to this class? (y/n): ");
                string ans = Console.ReadLine();
                if (!ans.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                    break;
            }

            if (c.StudentsCount >= SchoolClass.MAX_STUDENTS)
                Console.WriteLine("Reached maximum students for this class.");
        }

        // Returns a valid, unique ID (9 digits) or null if user typed X
        static string ReadValidUniqueIdOrStop(SchoolClass c)
        {
            while (true)
            {
                Console.Write("ID (9 digits): ");
                string id = Console.ReadLine().Trim();

                if (id.Equals("X", StringComparison.OrdinalIgnoreCase))
                    return null;

                //if (!IsValidIsraeliIdFormat(id))
                if (!IsValidIsraeliId(id))
                    {
                    Console.WriteLine("Invalid ID. Must be a real ID with exactly 9 digits.");
                    continue;
                }

                if (c.ContainsId(id))
                {
                    Console.WriteLine("This ID already exists in this class. Try again.");
                    continue;
                }

                return id; // OK
            }
        }

        // Simple validation: exactly 9 characters and all are digits
        static bool IsValidIsraeliIdFormat(string id)
        {
            if (id.Length != 9)
                return false;

            for (int i = 0; i < id.Length; i++)
            {
                if (!char.IsDigit(id[i]))
                    return false;
            }

            return true;
        }

        static bool IsValidIsraeliId(string id)
        {
            // Must be exactly 9 digits
            if (id.Length != 9) return false;

            for (int i = 0; i < 9; i++)
                if (!char.IsDigit(id[i]))
                    return false;

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int digit = id[i] - '0';
                int factor = (i % 2 == 0) ? 1 : 2;   // positions: 1,3,5.. *1 ; 2,4,6.. *2
                int product = digit * factor;

                if (product > 9) product -= 9;      // same as summing digits of product
                sum += product;
            }

            return (sum % 10 == 0);
        }

    }
}

