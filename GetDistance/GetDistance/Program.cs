using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GetDistance
{
    class Program
    {
        private static int CheckWord(string[] words, string word)
        {
            int idx = 0;
            if (Array.IndexOf(words, word) == -1)
            {
                idx = -1;
            }
            else
            {
                idx = Array.IndexOf(words, word);
            }
            return idx;
        }
        static void Main(string[] args)
        {
            string path;
            int idxWordOne = 0;
            int idxWordTwo = 0;
            string pattern = @"[-.?!)(,:]";
            string target = " ";
            Regex regex = new Regex(pattern);
            Console.WriteLine("Пожалуйста, введите путь до файла:");
            path = Console.ReadLine();
            string text = System.IO.File.ReadAllText(path).ToLower();
            string[] words = regex.Replace(text, target).Split(" ");
            Console.WriteLine("Пожалуйста, введите первое слово:");
            idxWordOne = CheckWord(words, Console.ReadLine().ToLower());
            Console.WriteLine("Пожалуйста, введите второе слово:");
            idxWordTwo = CheckWord(words, Console.ReadLine().ToLower());
            if(idxWordOne == -1 || idxWordTwo == -1)
            {
                Console.WriteLine("Введённое вами слово не найдено, попробуйте снова");
            } else
            {
                Console.WriteLine($"Расстояние между введённными вами словами: {Math.Abs(idxWordOne - idxWordTwo) - 1}");
            }
            ;
        }
    }
}
