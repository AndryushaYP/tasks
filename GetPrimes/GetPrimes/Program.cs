using System;

namespace GetPrimes
{
    class Program
    {
        private static bool IsPrime(int num)
        {
            bool result = true;
            if(num > 1)
            {
                for(int i = 2; i < num; i ++)
                {
                    if(num % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            } else
            {
                result = false;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int number;
            string result = "";
            Console.WriteLine("Введите диапазон (число n):");
            number = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                if(IsPrime(i))
                {
                    count++;
                    result += $"{Convert.ToString(i)}, ";
                }
            }

            Console.WriteLine(result);
            Console.WriteLine($"Кол-во простых чисел в диапазоне от 2 до {number}: {count}");

        }
    }
}
