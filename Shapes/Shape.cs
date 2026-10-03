using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Shape
    {
        //Fields / Properties
        //Static counter to keep track of the number of shapes created
        private static int _counter;
        protected int Count { get { return _counter; } }

        ////Unique Id for each shape
        //private int _idNum;
        //protected int IdNum { get { return _idNum; } }

        // Unique Id for each shape, now a 9-character string
        private string _uniqueIdNum;
        public string UniqueIdNum
        {
            get { return _uniqueIdNum; }

        }

        private ShapeColor _color;
        protected ShapeColor Color { get { return _color; } set { _color = value; } }

        //Use ConsoleColor instead of ShapeColor if you want to use the console colors
        //private ConsoleColor _color;
        //protected ConsoleColor Color { get { return _color; } set { _color = value; } }

        //Constructors
        public Shape() : this(ShapeColor.Red){ }
        public Shape(ShapeColor color = ShapeColor.Red)
        {
            _color = color;
            _counter++;
            //_idNum = _counter;
            _uniqueIdNum = _counter.ToString().PadLeft(9, '0');//_counter.ToString("D9"); // Assign and format the ID
        }
        //copy constructor
        public Shape(Shape other)
        {
            _color = other.Color;
            _counter++;
            //_idNum = _counter;
            _uniqueIdNum = _counter.ToString("D9"); // Assign and format the ID
        }

        //Methods

        //Abstract methods to be implemented by derived classes

        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract Shape Clone();

        //Override ToString method to display the shape's Id and Color
        public override string ToString()
        {
            return "My Id Num is " + this.UniqueIdNum + " and my Color is " + this.Color;
        }
    }

    //Enum to represent the color of the shape
    public enum ShapeColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
        Black,
        White
    }
}

