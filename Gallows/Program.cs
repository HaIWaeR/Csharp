using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace visilica
{
    class MyClass
    {
        // Получаем слово 
        public string GetWord(string answer)
        {
            string? word = null;

            Console.Clear();

            word = answer.ToLower();


            if (!string.IsNullOrEmpty(word))
            {
                // Используем StringBuilder для формирования итоговой строки
                var result = new System.Text.StringBuilder();

                // Преобразуем StringBuilder в строку без пробелов и не букв
                string finalResult = result.ToString();

                // Преобразуем итоговую строку в верхний регистр
                if (finalResult.Length > 0)
                {
                    word = finalResult.ToUpper();
                }
            }
            return word;
        }

        public string GetLetter()
        {
            string? input;

            // Запрашиваем у пользователя ввод буквы
            while (true)
            {
                Console.Write("Введите букву: ");
                //Console.Clear();
                input = Console.ReadLine();

                // Проверяем, что введено ровно 1 символ и он является буквой
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
                    return input.ToLower();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var (answer, hint) = FileDate.InputData();

                string tempHint = hint.ToUpper();

                MyClass verification = new MyClass();

                string word = answer.ToLower();

                PrintWord textOutput = new PrintWord();

                int count = 1;

                textOutput.PrintCubeWord(word, count, tempHint);
            }
        }
    }


    class PrintWord
    {
        public void Hint(string tempHint)
        {
            Console.WriteLine();
            Console.Write($" Подсказка: ");
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(tempHint.ToUpper());

            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }


        public void Design(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(" - ");
            }
            Console.WriteLine();
        }

        public void PrintCubeWord(string word, int count, string tempHint)
        {
            Console.Clear();
            

            Print FirstImage = new Print();

            char[] wordArray = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                wordArray[i] = word[i];
            }

            Design(word);

            string[] charCube = new string[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                charCube[i] = "█";
            }

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write($" {charCube[i]} ");
            }
            Console.WriteLine();

            Design(word);

            Print printInstance = new Print();

            while (count < 8)
            {
                Hint(tempHint);

                printInstance.HoverNumbers(count);

                MyClass verification = new MyClass();

                string letter = verification.GetLetter();

                List<int> indices = new List<int>();

                char searchLetter = letter[0];

                for (int i = 0; i < wordArray.Length; i++)
                {
                    if (wordArray[i] == searchLetter)
                    {
                        indices.Add(i);
                    }
                }

                bool foundAny = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (indices.Contains(i))
                    {
                        charCube[i] = word[i].ToString();
                        foundAny = true;
                    }
                }

                Console.Clear();

                Design(word);

                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write($" {charCube[i]} ");
                }
                Console.WriteLine();

                Design(word);

                if (!charCube.Contains("█"))
                {
                    Console.Clear();
                    Console.WriteLine($"\t\t\tПоздравляю ты отгадал слово <<{word}>> Ты ВЫИГРАЛ!!!");

                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;


                    Console.WriteLine($@"
                    
                                                    ▄▐
                                              ▄▄▄  ▄██▄
                                             ▐▀█▀▌    ▀█▄
                                             ▐█▄█▌      ▀█▄
                                              ▀▄▀   ▄▄▄▄▄▀▀
                                            ▄▄▄██▀▀▀▀
                                           █▀▄▄▄█ ▀▀
                                           ▌ ▄▄▄▐▌▀▀▀
                                        ▄ ▐   ▄▄ █ ▀▀
                                        ▀█▌   ▄ ▀█▀ ▀
                                               ▄▄▐▌▄▄
                                               ▀███▀█▄
                                              ▐▌▀▄▀▄▀▐▄
                                              ▐▀      ▐▌
                                              █        █
                                             ▐▌         █
                                           ▄▄▌         ▄▄▌

                    ");
                    Console.ForegroundColor = originalColor;
                    Console.ReadLine();
                    return; // Завершаем игру
                }

                if (!foundAny)
                {
                    count++;
                }
            }
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tК сожалению, вы проиграли. Загаданное слово было: " + word);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($@"
                    
            
                            ██╗░░░░░░█████╗░██╗░░██╗░█████╗░██████╗░░█████╗░
                            ██║░░░░░██╔══██╗██║░░██║██╔══██╗██╔══██╗██╔══██╗
                            ██║░░░░░██║░░██║███████║███████║██████╔╝███████║
                            ██║░░░░░██║░░██║██╔══██║██╔══██║██╔══██╗██╔══██║
                            ███████╗╚█████╔╝██║░░██║██║░░██║██║░░██║██║░░██║
                            ╚══════╝░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝

                    ");
            Console.ReadLine();

        }
    }
}
