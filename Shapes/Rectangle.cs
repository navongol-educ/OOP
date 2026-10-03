using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape, IRolleable
    {

        //Fileds / Properties
        private double _hight;
        public double Hight { get { return _hight; } } // set { if (value > 0) _hight = value; } }

        private double _width;
        public double Width { get { return _width; } } // set { if (value > 0) _width = value; } }

        //Constructors
        // Ctor with Defaults 
        // public Rectangle(double hight = 1, double width = 1, ShapeColor color = ShapeColor.Red) : base(color)
        public Rectangle(double hight, double width, ShapeColor color = ShapeColor.Red) : base(color)
        {
            if (hight > 0 && width > 0)
            {
                this._hight = hight; 
                this._width = width;
            }
        }      
        public Rectangle():this(1,1) { }

        //Copy Constructor
        public Rectangle(Rectangle other) : this(other._hight, other._width, other.Color) { }

        //Methods

        //Override GetPerimeter and GetArea methods
        public override double GetPerimeter() { return _hight * 2 + _width * 2; }
        public override double GetArea() { return _hight * _width; }

        //Override ToString method 
        public override string ToString()
        {
            return "I am a Rectangle Shape: " +  base.ToString();
        }

        //Override Clone method
        public override Shape Clone()
        {
            return new Rectangle(this);
        }

        //IRolleable implementation
        public void Roll()
        {
            Console.WriteLine("I am rolling");
        }
    }
}
