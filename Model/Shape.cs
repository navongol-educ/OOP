using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Shape
    {
        private static int _counter;
        private int _idNum;
        public Shape() 
        {
            _counter++;
           _idNum = _counter;
        }
        public abstract double GetPerimeter();
        public abstract double GetArea();

        public override string ToString()
        {
            return "My Id Num is " + _idNum;
        }
        //public int IdNum { get { return _idNum; } }
        //public int Count { get { return _counter; }
    }
}
