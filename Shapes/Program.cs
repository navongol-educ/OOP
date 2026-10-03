using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shapes
{
    public class Program
    {
        static void Main(string[] args)
        {


            // List<Shape> shapes = new List<Shape>();

            // Use a Dictionary where the key is the UniqueId (string) and the value is the Shape object.
            // We can store different types of Shapes (e.g., Rectangle, Circle) in this dictionary.
            Dictionary<string, Shape> shapeCollection = new Dictionary<string, Shape>();

            Rectangle rec = new Rectangle();
            Circle circle = new Circle();
            //Triangle tr = new Triangle(1, 1, 1, ShapeColor.Purple);
            Triangle tr = new Triangle();


            shapeCollection.Add(circle.UniqueIdNum, circle);
            shapeCollection.Add(tr.UniqueIdNum, tr);
            shapeCollection.Add(rec.UniqueIdNum, rec);

            foreach (var item in shapeCollection)
            {
                Console.WriteLine(item.Value.ToString());
                //if (item is IRolleable)
                //{
                //    ((IRolleable)item).Roll();
                //}

            }
        }   
    }
}
