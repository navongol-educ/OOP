using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Circle : Shape   //, IRolleable
    {
        //Fields / Properties
        private double _radius;
        public double Radius { get { return _radius; } set { if (value > 0) _radius = value; } }

        public const double PI = 3.14;

        //Constructors

        public Circle() : this(1) {  }  //default radius = 1

        public Circle(int radius) { this._radius = radius; }

        //Methods
        public override double GetPerimeter() { return PI * _radius * 2; }
        public override double GetArea() { return PI * _radius * _radius; }
        public override string ToString()
        {
            return "I am a Circle Shape: " + base.ToString();   //+ "and i am Rollable";
        }



        //public void Roll()
        //{
        //    Console.WriteLine("I am rolling");
        //}
    }
}
