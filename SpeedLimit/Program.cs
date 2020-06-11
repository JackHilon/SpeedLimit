using System;
using System.Collections.Generic;

namespace SpeedLimit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Speed Limit:
            // https://open.kattis.com/problems/speedlimit 

            // Speed in miles per hour  |   Total elapsed time in hours
            // -------------------------|---------------------------------
            //         20               |       2
            //         30               |       6
            //         10               |       7
            //--------------------------|---------------------------------
            
            // total distance = 20 * 2 + 30 * (6 - 2) + 10 * (7 - 6)





            PrintList(ListOfDistances());
        } // end main

        public static List<int> ListOfDistances()
        {
            List<int> ans = new List<int>();
            while (true)
            {
                var myCount = OneNumConverter();
                if (myCount == -1)
                    break;

                ans.Add(GetDistance(myCount));
            } // end while
            return ans;
        }

        private static int GetDistance(int myCount)
        {
            int[] res;
            int sum = 0;
            int firstTime = 0;
            for (int i = 0; i < myCount; i++)
            {
                res = Distance();
                sum = sum + res[0] * (res[1] - firstTime);
                firstTime = res[1];
            }
            return sum;
        }
        private static void PrintList(List<int> distances)
        {
            foreach (var distance in distances)
            {
                Console.WriteLine($"{distance} miles");
            }
        }
        private static int OneNumConverter()
        {
            var str = " ";
            var a = 0;
            str = Console.ReadLine();
            try
            {
                a = int.Parse(str);
                if (a == 0 || a < -1 || a > 10)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return OneNumConverter();
            }
            return a;
        }
        private static int[] Distance()
        {
            var str = "  ";
            string[] strArr = { " ", " " };
            int[] nums = { 0, 0 };

            str = Console.ReadLine();
            try
            {
                strArr = str.Split(' ', 2);
                if (strArr.Length != 2)
                    throw new IndexOutOfRangeException();
                nums[0] = int.Parse(strArr[0]);
                nums[1] = int.Parse(strArr[1]);
                if(nums[0] <= 0 || nums[0] > 90)
                    throw new ArgumentException();
                if (nums[1] <= 0 || nums[1] > 12)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return Distance();
            }
            return nums;
        }
    }
}
