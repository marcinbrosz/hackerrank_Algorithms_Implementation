using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_Algorithms_Implementation
{



    class DivisibleSumPairs
    {
        public static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int count = 0;
            int[] modBucket = new int[k];
            for (int i = 0; i < n; i++)
            {
                int modValue = ar[i] % k;
                int h1 = (k - modValue) % k;
                int h= modBucket[(k - modValue) % k];
                count += modBucket[(k - modValue) % k];
                modBucket[modValue]++;
            }

            return count;
            //O(n/2*n/2)
            //int count = 0;
            //int i1 = n - 1;
            //int _n = n / 2;
            //bool a = false;
            //if (n % 2 != 0)
            //{
            //    _n =  n / 2 + 1;
            //    a = true;
            //}
            //for (int i = 0; i < _n; i++, i1--)
            //{
            //    int j1 = n - 1;

            //    for (int j = 0; j < _n; j++, j1--)
            //    {
            //        if (j != _n - 1||!a)
            //        {
            //            if (i != _n - 1|| !a)
            //                if (i < j && (ar[i] + ar[j]) % k == 0)
            //                    count++;

            //            if (i1 < j && (ar[i1] + ar[j]) % k == 0)
            //                count++;
            //        }
            //        if (i != _n - 1 || !a)
            //            if (i < j1 && (ar[i] + ar[j1]) % k == 0)
            //                count++;

            //        if (i1 < j1 && (ar[i1] + ar[j1]) % k == 0)
            //            count++;


            //    }
            //}

            //return count;


            //with linq
            //return Enumerable
            //            .Range(0, n )
            //            .Select(i => Enumerable
            //            .Range(0, n )
            //            .Select(j => i < j && (ar[i] + ar[j]) % k == 0 ? 1 : 0)
            //            .Sum())
            //            .Sum();


        }
        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int result = divisibleSumPairs(n, k, ar);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
