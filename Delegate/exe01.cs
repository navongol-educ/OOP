using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class exe01
    {

        // סעיף 1: הגדרת ה"חוזה" (הטיפוס של ה-Delegate)
        // הגדרנו טיפוס שמסוגל להצביע על כל פונקציה שמקבלת אובייקט Student ומחזירה bool
        public delegate bool ClassFilter(Student s);

        // סעיף 2: פונקציה רגילה (static) שמתאימה בדיוק לחוזה של ה-Delegate
        public static bool IsExcellent(Student student)
        {
            return student.Grade >= 90;
        }

        //public static bool IsExcellent(Student student)
        //{
        //    return student.Name == "Avi";
        //}

        static void Main(string[] args)
        {
            // שורת הקסם שמסדרת את התמיכה בעברית בקונסולה!
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isTrue;

            //// חלק א
            //// יצירת אובייקט בדיקה של תלמיד
            Student testStudent = new Student { Name = "Avi", StudentClass = "G12-1", Grade = 95 };

            //// סעיף 3: יצירת משתנה מהטיפוס של ה-Delegate ושיוך הפונקציה אליו
            ClassFilter myFilter = IsExcellent;

            //// הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה IsExcellent)
            bool isExcellent = myFilter(testStudent);
            Console.WriteLine($"Is the student Excellent? {isExcellent}"); // יודפס: True


            // חלק ב 
            // סעיף 1: פעולה אנונימית (C# 2.0) - מגדירים את גוף הפונקציה "במקום" בלי שם
            myFilter = delegate (Student s)
            {
                return s.StudentClass == "G12-1";
            };

            isTrue = myFilter(testStudent);
            Console.WriteLine($"(Anonymous Function with delegate: Is the student Class G12-1? {isTrue}"); // יודפס: True

            // סעיף 2: ביטוי למבדה מלא - מחליפים את המילה delegate בסימן החץ (=>)
            myFilter = (Student s) => { return s.StudentClass == "G12-1"; };

            // הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה האנונימית)
            isTrue = myFilter(testStudent);
            Console.WriteLine($"Full Lambda Syntax: Is the student Class G12-1? {isTrue}"); // יודפס: True

            // סעיף 3: קיצורי תחביר (Syntax Sugar) - הגרסה הקצרה והמקצועית ביותר!
            // בגלל שיש רק פרמטר אחד, גוף קצר של שורה אחת והסקה אוטומטית של הטיפוס:
            myFilter = s => s.StudentClass == "G12-1";
            // הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה האנונימית)
            isTrue = myFilter(testStudent);
            Console.WriteLine($"Syntax Sugar: Is the student Class G12-1? {isTrue}"); // יודפס: True


            // חלק ג
            // שימוש ב-Func, Action ו-Predicate גנריים

            // סעיף 1: שימוש ב-Func גנרי (מקבל Student, מחזיר string)
            // הפרמטר האחרון בהגדרת ה-Func הוא תמיד סוג הערך המוחזר
            Func<Student, string> getUpperName = s => s.Name.ToUpper();
            Console.WriteLine(getUpperName(testStudent)); // יודפס:  (באותיות גדולות אם היה באנגלית)

            // סעיף 2: שימוש ב-Action גנרי (מקבל Student, אינו מחזיר ערך - void)
            Action<Student> printDetails = s => Console.WriteLine($"Name: {s.Name}, Class: {s.StudentClass}");
            printDetails(testStudent); // מפעיל את ההדפסה

            // סעיף 3: שימוש ב-Predicate גנרי (מקבל תמיד פרמטר אחד ומחזיר תמיד bool)
            // Predicate הוא למעשה קיצור דרך מובנה ל- Func<T, bool>
            Predicate<Student> isLongName = s => s.Name.Length > 4;
            Console.WriteLine($"Is name longer than 4 chars? {isLongName(testStudent)}");



            // חלק ד
            // שירשור פעולות (Multicast Delegates) - ניתן לשרשר מספר פונקציות לאותו משתנה Delegate

            // סעיף 1: הגדרת פעולת הדפסה ראשונה למשתנה notifier
            Action<Student> notifier = s => Console.WriteLine($"Start processing for: {s.Name}");

            // סעיף 2: שרשור פעולה נוספת לאותו המשתנה באמצעות האופרטור +=
            notifier += s => Console.WriteLine($"In class: {s.StudentClass}");

            // סעיף 3: הפעלה בודדת שמריצה את שתי הפונקציות בזו אחר זו לפי סדר הוספתן
            Console.WriteLine("--- Executing chained actions ---");
            notifier(testStudent);

            // חלק ה
            // שימוש ב-Delegate עם List<T> ו-LINQ


            // יצירת רשימת תלמידים מדומיינת לצורך הרצת הפתרונות
            List<Student> students = new List<Student>
        {
            new Student { Name = "Noa", StudentClass = "G12-2" },
            new Student { Name = "Yossi", StudentClass = "G12-2" },
            new Student { Name = "Roni", StudentClass = "G12-3" }
        };
            // LINQ - Language Integrated Query - מאפשרת לבצע שאילתות על אוספים בצורה נוחה וקריאה
            
            
            // סעיף 1: Count - ספירה לפי תנאי (מחזיר int)
            // הלמבדה משמשת כתנאי הבדיקה עבור כל איבר ברשימה
            // Count(...) - עושה שימוש בלמבדה כדי לבדוק כל איבר ברשימה ולהחזיר את מספר האיברים שמקיימים את התנאי
            // Count() - ללא "תנאי" - מחזיר את מספר האיברים ברשימה 
            Console.WriteLine(students.Count(s => s.StudentClass == "G12-2"));

            // סעיף 2: Find - איתור האיבר הראשון שמקיים את התנאי (מחזיר אובייקט Student או null)

            // Find(...) - עושה שימוש בלמבדה כדי לבדוק כל איבר ברשימה ולהחזיר את האיבר הראשון שמקיים את התנאי
            // Find() - ללא "תנאי" - מחזיר את האיבר הראשון ברשימה (או null אם הרשימה ריקה)
            Student firstNoa = students.Find(s => s.Name == "Noa");
            Console.WriteLine(firstNoa.ToString());

            // אפשר גם ישירות בלי להגדיר משתנה ביניים
            //Console.WriteLine(students.Find(s => s.Name == "Noa").ToString());

            // סעיף 3: Where - סינון ומציאת כל האיברים ועטיפתם ברשימה חדשה (מחזיר אוסף מסונן)
            // אנו מוסיפים .ToList() בסוף כדי להפוך את האוסף המסונן בחזרה לטיפוס של רשימה

            // Where(...) - עושה שימוש בלמבדה כדי לבדוק כל איבר ברשימה ולהחזיר את כל האיברים שמקיימים את התנאי
            // Where() - ללא "תנאי" - מחזיר את כל האיברים ברשימה
            List<Student> classYV3List = students.Where(s => s.StudentClass == "G12-3").ToList();
            foreach (var student in classYV3List)
            {
                Console.WriteLine(student.ToString());
            }
            //  ניתן בקיצור את הלולאה גם ישירות על הפונקציה Where אפשר גם בלי להגדיר משתנה ביניים
            //foreach (var student in students.Where(s => s.StudentClass == "G12-3").ToList())
            //{
            //    Console.WriteLine(student.ToString());
            //}



        }
    }

}

