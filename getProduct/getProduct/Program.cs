using System;
namespace getProduct
{
    class Program
    {

        //Сортируем массив по убыванию
        private static void SortArray(int[] numbers)
        {
            int temp;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = IsNegative(numbers[i]);
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    numbers[j] = IsNegative(numbers[j]);
                    if (numbers[i] < numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }

        //Проверка на отрицательное
        private static int IsNegative(int num)
        {
            if(num < 0)
            {
                num *= -1;
            }
            return num;
        }

        //Считаем произведение
        private static void GetProduct(int[] numbers)
        {
            int result = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i < 3)
                {
                    result *= numbers[i];
                }
            }
            Console.WriteLine("Произведение: {0}", result);
        }

        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 15, -20, -20, 7, 9 };
            SortArray(numbers);
            GetProduct(numbers);
        }
            
    }
}
