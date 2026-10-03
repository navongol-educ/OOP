using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rectangle : Shape
    {

        //Fileds / Properties
        private double _hight;
        public double Hight { get { return _hight; } set { if (value > 0) _hight = value; } }

        private double _width;
        public double Width { get { return _width; } set { if (value > 0) _width = value; } }

        //Constructors
        public Rectangle(double hight, double width) //:base()
        {
             this._hight = hight; this._width = width;
        }
        public Rectangle():this(1,1) 
        {
            //Do Something 
        }

        //Methods
        public override double GetPerimeter() { return _hight * 2 + _width * 2; }
        public override double GetArea() { return _hight * _width; }
        public override string ToString()
        {
            return "I am a Rectangle Shape: " +  base.ToString();
        }
       

    }
}
