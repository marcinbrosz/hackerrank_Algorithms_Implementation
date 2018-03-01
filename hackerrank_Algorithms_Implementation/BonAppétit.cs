using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_Algorithms_Implementation
{
    class BonAppétit
    {
        static string rest(int[] c,int k, int b)
        {
            int s=b-(c.Select(x => x).Sum()-c[k])/2;
            return b==0? "Bon Appetit":s.ToString();
        }
        static void Main(string[] args)
        {
            string n_k = Console.ReadLine();
            int n = Int32.Parse(n_k.Split(' ')[0]);
            int k= Int32.Parse(n_k.Split(' ')[1]);
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int b = Int32.Parse(Console.ReadLine());

            Console.WriteLine(rest(c, k, b));

        }
    }
}
