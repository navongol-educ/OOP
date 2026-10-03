using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape , IRolleable
    {
        //Fields / Properties
        private double _radius;
        public double Radius { get { return _radius; } } // set { if (value > 0) _radius = value; } }

        public const double PI = 3.14;

        //Constructors

        public Circle() : this(1, ShapeColor.Green) { }  //default radius = 1
        public Circle(double radius): this(radius, ShapeColor.Green) { }

        // Ctor with Defaults
        //public Circle(double radius = 1, ShapeColor color = ShapeColor.Green) : base(color) { this._radius = radius; }
        public Circle(double radius, ShapeColor color = ShapeColor.Green) : base(color) { this._radius = radius; }
        
        //Copy Constructor
        public Circle(Circle other) : this(other._radius, other.Color) { }




        //Methods
        public override double GetPerimeter() { return PI * _radius * 2; }
        public override double GetArea() { return PI * _radius * _radius; }
        public override string ToString()
        {
            return "I am a Circle Shape: " + base.ToString();   //+ "and i am Rollable";
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }

        public void Roll()
        {
            Console.WriteLine("I am rolling");
        }
    }
}


