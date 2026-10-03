using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Triangle : Shape
    {
        //Fields / Properties

        private double _a;
        public double A { get { return _a; } set { if (value > 0) _a = value; } }

        private double _b;
        public double B { get { return _b; } set { if (value > 0) _b = value; } }

        private double _c;
        public double C { get { return _c; } set { if (value > 0) _c = value; } }

        //Constructors
        public Triangle(double a, double b, double c)
        {
            if(a + c >= b && a + b >= c && b + c >= a)
            {
                this._a = a;
                this._b = b;
                this._c = c;
            }
            else { _a = 1; _b = 1; _c = 1; }
        }
        public Triangle() : this(1, 1, 1) { }

        //Methods
        public override double GetPerimeter() { return _a + _b + _c; }
        public override double GetArea() { double s = (_a + _b + _c) / 2; return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c)); }
        
        public override string ToString()
        {
            return "I am a Triangle Shape: " + base.ToString();
        }
    }
}
