using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : Shape, IRolleable
    {
        //Fields / Properties

        private double _a;

        public double A { get { return _a; } }// set { if (value > 0) _a = value; } }
        //public double A { get => _a; set => _a = value > 0 ? value : _a; }
        //public double A { get; set; }


        private double _b;
        public double B { get { return _b; } } //set { if (value > 0) _b = value; } }

        private double _c;
        public double C { get { return _c; } } //set { if (value > 0) _c = value; } }

        //Constructors
        // Defualts - public Triangle(double a = 1, double b = 1, double c = 1, ShapeColor color = ShapeColor.Purple) : base(color)
        public Triangle(double a, double b, double c, ShapeColor color = ShapeColor.Purple) : base(color) 
        {
            if ((a + c >= b && a + b >= c && b + c >= a) && (a > 0 && b > 0 && c > 0))
            {
                this._a = a;
                this._b = b;
                this._c = c;
            }
            else { this._c = 1; this._b = 1; this._b = 1; }
        }
        public Triangle() : this(1, 1, 1) { }

        public Triangle(Triangle other) : this(other._a, other._b, other._c, other.Color) { }



        //Methods

        //Override GetPerimeter and GetArea methods
        public override double GetPerimeter() { return _a + _b + _c; }
        public override double GetArea() { double s = (_a + _b + _c) / 2; return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c)); }

        //Override ToString method
        public override string ToString()
        {
            return "I am a Triangle Shape: " + base.ToString();
        }
        //Override Clone method
        public override Shape Clone()
        {
            return new Triangle(this);
        }

        //IRolleable implementation
        public void Roll()
        {
            Console.WriteLine("I am rolling");
        }
    }
}
