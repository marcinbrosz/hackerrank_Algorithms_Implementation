using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerrank_Algorithms_Implementation
{
    class MigratoryBirds
    {
        static int migratoryBirds(int n, int[] ar)
        {

            ////with dictionary
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //int i2 = n - 1;
            //for (int i = 0; i < n / 2; i++, i2--)
            //{
            //    int temp = 1;

            //    if (!map.TryGetValue(ar[i], out temp))
            //        map.Add(ar[i], 1);
            //    else
            //        map[ar[i]]++;

            //    if (!map.TryGetValue(ar[i2], out temp))
            //        map.Add(ar[i2], 1);
            //    else
            //        map[ar[i2]]++;

            //}


            //if (n % 2 != 0)
            //{
            //    int temp = 1;
            //    if (!map.TryGetValue(ar[n / 2], out temp))
            //        map.Add(ar[n / 2], 1);
            //    else
            //        map[ar[n / 2]]++;


            //}

            //return map.OrderByDescending(x => x.Value).ThenBy(y => y.Key).First().Key;

            ////with linq
            //return ar.GroupBy(x => x)
            //.Select(y=>new {Bird=y.Key,Count = y.Count() })
            //.OrderByDescending(z=> z.Count)
            //.ThenBy(k=>k.Bird)
            //.FirstOrDefault().Bird;


            // with for
            int[] type = new int[5];
            int i2 = n - 1;
            int asd = n / 2;
            for (int i = 0; i < n / 2; i++, i2--)
            {
                type[ar[i] - 1]++;
                type[ar[i2] - 1]++;
            }

            if (n % 2 != 0)
                type[ar[n / 2 + 1]]++;

            return Array.IndexOf(type, type.Max()) + 1;
        }
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int result = migratoryBirds(n, ar);
            Console.WriteLine(result);
        }
    }



}
