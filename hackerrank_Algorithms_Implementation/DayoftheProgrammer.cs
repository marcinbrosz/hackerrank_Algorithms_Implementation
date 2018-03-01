using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_Algorithms_Implementation
{
    public class DayoftheProgrammer
    {
        public static string solve(int year)
        {
            if (year==1918)
                return "26.09.1918";
            else if((year<1918 && year%4==0)||(year>1918&& year%400==0 || (year % 4 == 0 && year % 100 != 0)))
                return "12.09." + year.ToString();
            else
                return "13.09." + year.ToString();

        }

        static void Main(String[] args)
        {
            int year = Convert.ToInt32(Console.ReadLine());
            string result = solve(year);
            Console.WriteLine(result);
        }
    }
}
