using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        // Contract definition 01
        // params and ret value
        public delegate int DelegateMath(int a, int b);
        // params and no ret value
        public delegate void PrintMsg( string msg );
        // one parm ret value bool
        public delegate bool IsPair( int a );


        // Method same as the contract
        public static  int Add (int a, int b) {  return a + b; }

        static void Main(string[] args)
        {
            // Use Delegate
            DelegateMath doMath = Add;
            int result = doMath(1, 2);

            // Use Delegate anonymous with parms and ret values
            DelegateMath doMathA = (int a, int b) => a + b;
            result = doMathA(1, 2);

            // *Func generic*  delegate anonymous with parms and ret values
            //Add
            Func<int, int, int> doMathF = (int a, int b) => a + b;
            //Mult
            //doMathF += (int a, int b) => a * b;

            result = doMathF(1, 2); // 3 or 2


            //Lambda
            //Long
            DelegateMath doLambdaLong = (int a, int b) => { return a + b; };

            //Semi
            DelegateMath doLambdaSemi = (a,b) => { return a + b; };

            //Short
            DelegateMath doLambda = (a, b) => a + b;




            // Use Delegate anonymous with parms no ret values
            PrintMsg printMsg = msg => { Console.WriteLine(msg); };
            printMsg("Hello");

            // *Action generic*  delegate anonymous no ret values
            Action<string> printMsgA = (string msg) => Console.WriteLine(msg);
            printMsgA("hello");




            // Use Delegate anonymous one pram ret value bool
            IsPair  isPair = num => num % 2 == 0;
            isPair(10);

            // *Predicate generic*  delegate anonymous one param ret value bool
            Predicate<int> isPairP = num => num % 2 == 0;
            isPairP(9);







        }
    }
}
