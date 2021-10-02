using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace GetDistance
{
    class Program
    {
        private static List<int> GetResultList(int count, int[] arr1, int[] arr2, List<int> result)
        {
            if (count == arr1.Length)
            {
                return result;
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result.Add(Math.Abs(arr1[count] - arr2[i]));
            }
            return GetResultList(count + 1, arr1, arr2, result);
        }
        static void Main(string[] args)
        {
            List<int> allIdxFirstWord = new List<int>() {};
            List<int> allIdxSecondWord = new List<int>() {};
            List<int> resultList = new List<int>() { };

            string path;
            string pattern = @"[-.?!)(,:]";
            string target = " ";
            Regex regex = new Regex(pattern);
            Console.WriteLine("Пожалуйста, введите путь до файла:");
            path = Console.ReadLine();
            Console.WriteLine("Пожалуйста, введите первое слово:");
            string firstWord = Console.ReadLine().ToLower();
            Console.WriteLine("Пожалуйста, введите второе слово:");
            string secondWord = Console.ReadLine().ToLower();
            string text = System.IO.File.ReadAllText(path).ToLower();
            string[] words = regex.Replace(text, target).Split(" ");

            for(int i = 0; i < words.Length; i ++)
            {
                if(words[i] == firstWord)
                {
                    allIdxFirstWord.Add(i);
                }
                if(words[i] == secondWord)
                {
                    allIdxSecondWord.Add(i);
                }
            }

            resultList = GetResultList(0, allIdxFirstWord.ToArray(), allIdxSecondWord.ToArray(), resultList);

            if (allIdxFirstWord.ToArray().Length == 0)
            {
                Console.WriteLine($"Слово '{firstWord}' не найдено!");

            } else if (allIdxSecondWord.ToArray().Length == 0)
            {
                Console.WriteLine($"Слово '{secondWord}' не найдено!");

            } else
            {
                int[] indexes = resultList.ToArray();
                Array.Sort(indexes);
                Console.WriteLine($"Минимальное расстояние: {indexes[0] - 1}");
                Console.WriteLine($"Максимальное расстояние: {indexes[indexes.Length - 1] - 1}");
            }
            
        }
    }
}
