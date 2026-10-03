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
            return student.Name == "אבי";
        }

        static void Main(string[] args)
        {
            // שורת הקסם שמסדרת את התמיכה בעברית בקונסולה!
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool isTrue;

            //// חלק א
            //// יצירת אובייקט בדיקה של תלמיד
            Student testStudent = new Student { Name = "אבי", StudentClass = "יב1" };

            //// סעיף 3: יצירת משתנה מהטיפוס של ה-Delegate ושיוך הפונקציה אליו
            ClassFilter myFilter = IsExcellent;

            //// הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה IsExcellent)
            bool isAvi = myFilter(testStudent);
            Console.WriteLine($"Is the student Avi? {isAvi}"); // יודפס: True


            // חלק ב 
            // סעיף 1: פעולה אנונימית (C# 2.0) - מגדירים את גוף הפונקציה "במקום" בלי שם
            myFilter = delegate (Student s)
            {
                return s.StudentClass == "יב1";
            };

            isTrue = myFilter(testStudent);
            Console.WriteLine($"(Anonymous Function with delegate: Is the student Class יב1? {isTrue}"); // יודפס: True


            // סעיף 2: ביטוי למבדה מלא - מחליפים את המילה delegate בסימן החץ (=>)
            myFilter = (Student s) => { return s.StudentClass == "יב1"; };

            // הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה האנונימית)
            isTrue = myFilter(testStudent);
            Console.WriteLine($"Full Lambda Syntax: Is the student Class יב1? {isTrue}"); // יודפס: True

            // סעיף 3: קיצורי תחביר (Syntax Sugar) - הגרסה הקצרה והמקצועית ביותר!
            // בגלל שיש רק פרמטר אחד, גוף קצר של שורה אחת והסקה אוטומטית של הטיפוס:
            myFilter = s => s.StudentClass == "יב1";

            // הפעלת ה-Delegate (מפעיל בעקיפין את הפונקציה האנונימית)
            isTrue = myFilter(testStudent);
            Console.WriteLine($"Syntax Sugar: Is the student Class יב1? {isTrue}"); // יודפס: True


            // חלק ג
            // שימוש ב-Func, Action ו-Predicate גנריים

            // סעיף 1: שימוש ב-Func גנרי (מקבל Student, מחזיר string)
            // הפרמטר האחרון בהגדרת ה-Func הוא תמיד סוג הערך המוחזר
            Func<Student, string> getUpperName = s => s.Name.ToUpper();
            Console.WriteLine(getUpperName(testStudent)); // יודפס: אבי (באותיות גדולות אם היה באנגלית)

            // סעיף 2: שימוש ב-Action גנרי (מקבל Student, אינו מחזיר ערך - void)
            Action<Student> printDetails = s => Console.WriteLine($"שם: {s.Name}, כיתה: {s.StudentClass}");
            printDetails(testStudent); // מפעיל את ההדפסה

            // סעיף 3: שימוש ב-Predicate גנרי (מקבל תמיד פרמטר אחד ומחזיר תמיד bool)
            // Predicate הוא למעשה קיצור דרך מובנה ל- Func<T, bool>
            Predicate<Student> isLongName = s => s.Name.Length > 4;
            Console.WriteLine($"Is name longer than 4 chars? {isLongName(testStudent)}");



            // חלק ד
            // שירשור פעולות (Multicast Delegates) - ניתן לשרשר מספר פונקציות לאותו משתנה Delegate

            // סעיף 1: הגדרת פעולת הדפסה ראשונה למשתנה notifier
            Action<Student> notifier = s => Console.WriteLine($"התחלת תהליך עבור: {s.Name}");

            // סעיף 2: שרשור פעולה נוספת לאותו המשתנה באמצעות האופרטור +=
            notifier += s => Console.WriteLine($"הכיתה המשויכת היא: {s.StudentClass}");

            // סעיף 3: הפעלה בודדת שמריצה את שתי הפונקציות בזו אחר זו לפי סדר הוספתן
            Console.WriteLine("--- הפעלת שרשור פעולות ---");
            notifier(testStudent);

            // חלק ה
            // שימוש ב-Delegate עם List<T> ו-LINQ


            // יצירת רשימת תלמידים מדומיינת לצורך הרצת הפתרונות
            List<Student> students = new List<Student>
        {
            new Student { Name = "נועה", StudentClass = "יב2" },
            new Student { Name = "יוסי", StudentClass = "יב2" },
            new Student { Name = "רוני", StudentClass = "יב3" }
        };

            // סעיף 1: Count - ספירה לפי תנאי (מחזיר int)
            // הלמבדה משמשת כתנאי הבדיקה עבור כל איבר ברשימה
            int countYV2 = students.Count(s => s.StudentClass == "יב2");
            Console.WriteLine(countYV2);

            // סעיף 2: Find - איתור האיבר הראשון שמקיים את התנאי (מחזיר אובייקט Student או null)
            Student firstNoa = students.Find(s => s.Name == "נועה");
            Console.WriteLine(firstNoa.ToString());


            // סעיף 3: Where - סינון ומציאת כל האיברים ועטיפתם ברשימה חדשה (מחזיר אוסף מסונן)
            // אנו מוסיפים .ToList() בסוף כדי להפוך את האוסף המסונן בחזרה לטיפוס של רשימה
            List<Student> classYV3List = students.Where(s => s.StudentClass == "יב3").ToList();
            Console.WriteLine(classYV3List.ToString());

        }
    }

}

