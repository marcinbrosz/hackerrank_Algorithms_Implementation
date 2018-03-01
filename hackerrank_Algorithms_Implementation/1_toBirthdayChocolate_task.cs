using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace hackerrank_Algorithms_Implementation
{
    public static class BetweenExtensions
    {
        public static bool IsBeetwen<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return min.CompareTo(value) <= 0 && max.CompareTo(value) >= 0;
        }
    }
    class Program
    {

        /*
         * If the difference between the grande  and the next multiple of 5 is less than 3, round grande up to the next multiple of 5.
           If the value of grande is less than 38, no rounding occurs as the result will still be a failing grade.
         */
        static int[] solve(int[] grades)
        {

            return grades.Select(x => x % 5 >= 3 && x>37 
                            ? x + (5 - (x % 5))
                            : x).ToArray();
        }

        static int[] Apple_and_Orange(int s, int t,int a, int b, int[] arr_m,int[] arr_n)
        {
            int apple = arr_m.Select(x =>  (a + x) >= s&& (a+x)<=t ? 1 : 0).Sum();
            int oran = arr_n.Select(y => (b + y) <= t && (b + y) >= s ? 1 : 0).Sum();
            return new int[2] { apple, oran };
        }


        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v2 >= v1 || x2 <= x1)
                return "NO";
            else
            {

                if ((v1 != v2) && ((x2 - x1) % (v1 - v2)) == 0)
                    return "YES";
                else
                    return "NO";
            }
        }

        static List<string> BigSorting(string[] temp)
        {
            List<BigInteger> big = new List<BigInteger>();
            big = temp.Select(x => BigInteger.Parse(x)).ToList();
            big.Sort();
            temp = big.Select(x => x.ToString()).ToArray();
            return temp.ToList();
        }

        static int getTotalX(int[] a, int[] b)
        {
            /* int x = 1, r = 0, j = 0, count = 0;
             int[] d = new int[101];
             for (x = 1; x < 101; x++)
             {
                 int c = 0;
                 for (int i = 0; i < a.Length; i++)
                 {
                     if (x % a[i] == 0 && x >= a[i])
                     {
                         c++;
                     }
                 }
                 if (c == a.Length)
                 {
                     d[j] = x;
                     r++;
                     j++;
                 }
             }
             for (j = 0; j < r; j++)
             {
                 int c = 0;
                 for (int i = 0; i < b.Length; i++)
                 {
                     if (b[i] % d[j] == 0)
                     {
                         c++;
                     }
                 }
                 if (c == b.Length)
                 {
                     count++;
                 }
             }
             return count;*/
            int result = 0;
            //result += b.Select(x =>
            //            !b.Select(y => x % y == 0 ? 1 : 0)
            //            .Contains(0) &&
            //            !a.Select(x1 => x % x1 == 0 ? 1 : 0).Contains(0)
            //            ? 1 : 0).Sum();

            result += a.Select(x =>
                a.Select(y => x % y == 0 ? 1 : 0)
                .Contains(0) &&
                b.Select(x1 => x % x1 == 0 ? 1 : 0).Contains(0)
                ? 1 : 0).Sum();

            return result;
        }


        static int[] getRecord(int[] s)
        {
            List<int> temp = s.ToList();
            int newRecMax = 0;
            int newRecMin = 0;
            int max = s[0];
            int min = s[0];
            
            
            for(int i = 0; i < s.Length; i++)
            {
                if(max < temp[i])
                {
                    max = temp[i];
                    newRecMax++;
                }
                if (min > temp[i])
                {
                    min = temp[i];
                    newRecMin++;
                }
            }
            
            
            return new int[] { newRecMax, newRecMin };
        }

        static string super_reduced_string(string s)
        {
            string result = s;
            for(int i = 0; i < result.Length; i++)
            {
                if ((i + 1) < result.Length)
                    if (result[i] == result[i + 1])
                    {
                        result = result.Remove(i, 2);
                        i = -1;
                    }

            }
            
            return string.IsNullOrEmpty(result) ? "Empty String": result;
        }

        static int CamelCase(string s)
        {

            //with linq
            //return s.Select((x, i) => i>0 & x.ToString() == x.ToString().ToUpper() ? 1 : 0)
            //        .Sum()+1;


            //with Regex
            return s.Length - Regex.Replace(s, @"[A-Z]", "").Length+1;
        }


        //sprawdza czy string ma taka forme yxyxy 
        static int super_reduced(string s)
        {
            string result = s;
            for (int i = 0; i < result.Length; i++)
            {
                if ((i + 1) < result.Length)
                    if (result[i] == result[i + 1])
                        return 0;
            }

            return s.Length;
        }
            public static readonly int NUM_LETTERS = 26;
            static int TwoCharacters_ver2(string s) 
            {
                int length = s.Length;
                int[,] pair = new int[NUM_LETTERS, NUM_LETTERS];
                int[,] count = new int[NUM_LETTERS,NUM_LETTERS];

                for (int i = 0; i < length; i++)
                {
                    char letter = s[i];
                    int letterNum = letter - 'a';

                    /* Update row */
                    for (int col = 0; col < NUM_LETTERS; col++)
                    {
                        if (pair[letterNum,col] == letter)
                        {
                            count[letterNum,col] = -1;
                        }
                        if (count[letterNum,col] != -1)
                        {
                            pair[letterNum,col] = letter;
                            count[letterNum,col]++;
                        }
                    }   

                    /* Update column */
                    for (int row = 0; row < NUM_LETTERS; row++)
                    {
                        if (pair[row,letterNum] == letter)
                        {
                            count[row,letterNum] = -1;
                        }
                        if (count[row,letterNum] != -1)
                        {
                            pair[row,letterNum] = letter;
                            count[row,letterNum]++;
                        }
                    }
                }

                /* Find max in "count" array */
                int max = 0;
                for (int row = 0; row < NUM_LETTERS; row++)
                {
                    for (int col = 0; col < NUM_LETTERS; col++)
                    {
                        max = Math.Max(max, count[row,col]);
                    
                    }
                }

                return max;
            }

        static int TwoCharacters(string s)
        {
            int countLetter = 0;
            int deletedLetter = 0;
            List<char> diffLetter = new List<char>();
            int result = 0;
            foreach(char c in s)
            {
                if (!diffLetter.Any() || !diffLetter.Contains(c))
                    diffLetter.Add(c);
            }
            countLetter = diffLetter.Count();   
            if(countLetter>2)
                deletedLetter = countLetter==2 ? countLetter : countLetter-2;
            else
                return countLetter<2 ? 0 : 2;
            string temp = string.Empty;
             

                for (int j = 0; j < countLetter; j++)
                {
                    
                    //int y = 0;
                    char temp_char = diffLetter[j];
                    //temp = Regex.Replace(temp, temp_char.ToString(), "");
                    for (int i = 0; i < diffLetter.Count; i++)
                    {
                        temp = s;
                        temp = Regex.Replace(temp, temp_char.ToString(), "");
                        //int y_temp = y;
                        if (i != j & i>j & i<diffLetter.Count)
                        {
                            for (int x = 0; x < deletedLetter - 1; x++)
                            {
                                if (i < diffLetter.Count)
                                {
                                    temp = Regex.Replace(temp, diffLetter[i].ToString(), "");

                                    if (deletedLetter - 1 > 1)
                                        i++;
                                }

                            

                            }
                        if (deletedLetter - 1 > 1)
                            i -= 2;

                        int t = super_reduced(temp);
                            result = t > result ? t : result;
                            

                        }

                    }
                }


            return result;
        }

        static string CaesarCipher(string unencrypted, int cipher)
        {

            //very short
            //string res = string.Empty;
            //foreach (char c in unencrypted)
            //{
            //    if (char.IsLetter(c))
            //    {
            //        char a = char.IsUpper(c) ? 'A' : 'a';
            //        res += (char)(a + ((c - a + cipher) % 26));
            //    }
            //    else
            //        res += c;
            //}



            List<char> result = new List<char>();
            int count = 'z' - 'a';
            //adder 
            void AdderCaesarCipher(char x, char lastChar)
            {
                if (cipher > count)
                {

                    double divCipher = (double)cipher / count;
                    if (divCipher > 1.0)
                    {
                        int cipher_temp = (int)(count * Math.Round(divCipher - (int)divCipher, 2)) - (int)divCipher;

                        result.Add(
                            char.IsLetter((char)(x + cipher_temp)) && (char)(x + cipher_temp) <= lastChar
                                ? (char)(x + cipher_temp) : (char)('a' + (x + cipher_temp) - 'z' - 1));

                    }
                }
                else
                {
                    result.Add(
                        char.IsLetter((char)(x + cipher)) && (char)(x + cipher) <= lastChar
                            ? (char)(x + cipher) : (char)('a' + (x + cipher) - 'z' - 1));
                }


            }
            foreach (char x in unencrypted)
            {
                if (char.IsLetter(x) && char.IsLower(x))
                {
                    AdderCaesarCipher(x, 'z');
                }
                else if (char.IsLetter(x) && char.IsUpper(x))
                {
                    AdderCaesarCipher(x, 'Z');
                }
                else
                {
                    result.Add(x);
                }
            }

            return string.Concat(result.Select(x=>x));
        }


        static int BirthdayChocolate(int[] s, int d, int m)
        {
            int res = 0;
            //with temp list
            //List<int> temp = s.ToList();
            //int i = 1;
            //while (temp.Count >= m)
            //{
            //    if (temp.Take(m).Sum() == d)
            //        res++;
            //    temp.Clear();
            //    temp.AddRange(s.Skip(i));
            //    i++;
            //}
            //without temp list
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Skip(i).Take(m).Sum() == d)
                    res++;
            }
            return res;
        }

        static int MarsExploration(string input)
        {
            int res = 0;
            string s = "SOS";
            //for (int i = 0; i < input.Length-2; i++)
            //{
            //    int i_temp = i;
            //    if (!(input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString() == s))
            //    {
            //        for(int j = 0; j < s.Length; j++)
            //        {
            //            if (input[i_temp] != s[j])
            //                res++;
            //            i_temp++;
            //        }
            //    }
            //    i = i + 2;
            //}

            //with take
            //for (int i = 0; i < input.Length - 2; i++) {
            //    string temp =string.Join("", input.Skip(i).Take(3).ToArray());
            //    if (temp != s)
            //    {
            //        res+=temp.Select((x, j) => x != s[j] ? 1 : 0).Sum();
            //    }
            //    i += 2;
            //}

            //with one for
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != s[i % 3])
                    res++;
            }

                return res;
        }

        static void Main(string[] args)
        {
            /*//to solve 
            int[]  temp = solve(new int[] { 73, 67, 38, 33 });
            */
            //to apple and orange
            //Apple_and_Orange(7, 11, 5, 15, new int[3] { -2, 2, 1 }, new int[2] { 5, -6 }).ToList().ForEach(Console.WriteLine);
            //to kangaroo
            //Console.WriteLine( kangaroo(0 ,3, 4, 2));
            //to getTotalX
            /*List<int> a = new List<int> { 2, 4 };
            List<int> b = new List<int> { 16, 32, 96 };
            Console.WriteLine(getTotalX(a.ToArray(), b.ToArray()));*/


            //to getRecord
            //int[] s = new int[] { 3 ,4 ,21, 36 ,10 ,28 ,35, 5, 24, 42 };
            //int[] result = getRecord(s);
            //Console.Write(string.Join(" ", result));

            //to super_reduced_string
            //Console.WriteLine( super_reduced_string("baab"));

            //to CamelCase
            //Console.Write(CamelCase("saveChangesInTheEditor"));


            //to big sort
            //string[] unsorted = new string[] {"6",
            //"31415926535897932384626433832795",
            //"1",
            //"3",
            //"10",
            //"3",
            //"5" };

            //Array.Sort(unsorted, (string a, string b) => {
            //    if (a.Length == b.Length)
            //        return string.Compare(a, b, StringComparison.Ordinal);
            //    return a.Length - b.Length;
            //});
            //Console.WriteLine(string.Join("\n", unsorted));
            //for data type
            //int i = 4;
            //double d = 4.0;
            //string s = "asd ";

            //int i2 = 0;
            //double d2 = 0.0;
            //string s2 = string.Empty;

            //i2 = Convert.ToInt32(Console.ReadLine());
            //d2 = Convert.ToDouble(Console.ReadLine());
            //s2 = Console.ReadLine();

            //Console.WriteLine(i + i2);
            //Console.WriteLine("{0:N1}", (d + d2));
            //Console.WriteLine(s + s2);
            //for TwoCharacters_ver2
            //string s = "pvmaigytciycvjdhovwiouxxylkxjjyzrcdrbmokyqvsradegswrezhtdyrsyhg";
            //Console.WriteLine(s.Length<2 ? "0": TwoCharacters_ver2(s).ToString());
            //Console.WriteLine("end");
            //for ceasar cipher
            //Console.WriteLine( CaesarCipher("6DWV95HzxTCHP85dvv3NY2crzt1aO8j6g2zSDvFUiJj6XWDlZvNNr", 87));

            //for Birthday Chocolate
            //int[] s = new int[] { 4 };
            //int d = 4;
            //int m = 1;
            //BirthdayChocolate(s, d, m);


            //for Mars Exploration
            string s = "SOSSPSSQSSOR";
            MarsExploration(s);
            Console.Read();
        }
    }
}
