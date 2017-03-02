using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Converter.ToLong("-200"));
            Console.WriteLine(Converter.ToLong("200"));
            Console.WriteLine(Converter.ToLong("+200"));
            //Console.WriteLine(Converter.ToLong("-2f00"));
            Console.WriteLine(Converter.ToLong("-200  "));
        }
    }

    public static class Converter
    {
        private static string pattern = "^[+-]?\\d+$";

        public static long ToLong(string str)
        {
            Regex rex = new Regex(pattern);
            if (!rex.IsMatch(str))
            {
                throw new ArgumentException("String is not a number");
            }

            long result = 0;
            int i = 0;
            long multipler = 1;
            if (str[0] == '-')
            {
                multipler = -1;
                i++;
            }
            if (str[0] == '+')
            {
                i++;
            }

            for (; i < str.Length; i++)
            {
                result *= 10;
                result += str[i] - '0';
            }

            return result * multipler;
        }
    }
}