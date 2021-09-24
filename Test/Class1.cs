using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Class1
    {
        static Class1()
        {
            _arr1 = InitArr(5000000);
            _arr2 = new List<int>();
            _arr2 = _arr1.Take(10000).ToList();
        }

        static List<int> _arr1;
        static List<int> _arr2;

        public class BenchmarkAttribute : Attribute
        {
        }

        [Benchmark]
        public static void SortQuick()
        {
            //PrintArr(_arr1);
            _arr1.Sort();
            //PrintArr(_arr1);
        }

        [Benchmark]
        public static void SortLong()
        {
            //PrintArr(_arr2);
            BubbleSort(_arr2);
            //PrintArr(_arr2);
        }

        static void BubbleSort(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
            }
        }

        static void PrintArr(List<int> arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static List<int> InitArr(int n)
        {
            Random r = new Random(0); //no random, need fixed result
            List<int> arr = new List<int>();
            for (int i = 0; i < n; i++)
            {
                arr.Add(r.Next(0, 100));
            }
            return arr;
        }
    }
}
