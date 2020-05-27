using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        public int multiplyDigitsTogether(int number)
        {
            if (number/10  == 0)
                return number;

            return multiplyDigitsTogether(number / 10) * (number % 10);
        }
        public static void Main(string[] args)
        {
            Program x = new Program();
            Console.WriteLine(x.multiplyDigitsTogether(1234));
        }
    }
}
