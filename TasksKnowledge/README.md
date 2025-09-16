using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace itHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayUserInfo();

            Task1();

            DisplayUserInfo();

            Task2();

            DisplayUserInfo();

            Task3();

            DisplayUserInfo();

            Task4();

            DisplayUserInfo();

            Task5();

            DisplayUserInfo();
        }

        public static void Task5()
        {
            int lowerBorder;
            while (true)
            {
                Console.Write("Введите нижнюю границу: ");
                lowerBorder = int.Parse(Console.ReadLine());
                if (lowerBorder >= 0)
                    break;
                else
                    Console.WriteLine("Ваше значение должно быть >= 0");
            }

            int upperBorder;
            while (true)
            {
                Console.Write("Введите верхнюю границу: ");
                upperBorder = int.Parse(Console.ReadLine());
                if (upperBorder <= 1000000000 && upperBorder > lowerBorder)
                    break;
                else
                    Console.WriteLine("Ваше значение должно быть <= 1.000.000.000 и больше \"A\"");
            }


            for (int i = lowerBorder; i <= upperBorder; i++)
            {
                string stringNumber = i.ToString();
                int[] array = new int[stringNumber.Length];

                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = int.Parse(stringNumber[j].ToString());
                }

                int temporaryStorage = 0;

                for (int j = 0; j < stringNumber.Length; j++)
                {
                    if (j == 0)
                    {
                        if (stringNumber.Length == 1)
                        {
                            Console.WriteLine(stringNumber);
                            break;
                        }

                        temporaryStorage = array[j];
                        continue;
                    }

                    if (array[j] >= temporaryStorage)
                    {
                        temporaryStorage = array[j];

                        if (j == array.Length - 1)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }
        }

        public static void Task4()
        {
            int N;
            while (true)
            {
                Console.Write("Введите N: ");
                N = int.Parse(Console.ReadLine());
                if (N >= 1 && N <= 20)
                    break;
                else
                    Console.WriteLine("N должна быть >= 1 и <= 20");
            }

            // ВПЕРВЫЕ ИСПОЛЬЗУЮ long XD до этого переполнения ни разу небыло ")
            // ядерный Ганди скажет спасибо! 
            // https://ru.wikipedia.org/wiki/%D0%AF%D0%B4%D0%B5%D1%80%D0%BD%D1%8B%D0%B9_%D0%93%D0%B0%D0%BD%D0%B4%D0%B8

            long[] factorialArray = new long[N];
            for (int i = 0; i < N; i++)
            {
                long factorialResult = 1;

                for (int j = 1; j <= i + 1; j++)
                {
                    factorialResult *= j;
                }

                factorialArray[i] = factorialResult;
            }

            long sum = 0;
            for (int i = 0; i < factorialArray.Length; i++)
            {
                Console.Write($"{factorialArray[i]} ");
                sum += factorialArray[i];
            }
            Console.WriteLine();
            Console.WriteLine($"Сумма факториалов: {sum}");

        }
        public static void Task3()
        {
            Console.Write("Введите A: ");
            int A = int.Parse(Console.ReadLine());

            int B;
            while (true)
            {
                Console.Write("Введите B: ");
                B = int.Parse(Console.ReadLine());
                if (B >= A)
                    break;
                else
                    Console.WriteLine("B должно быть >= A");
            }

            int K;
            while (true)
            {
                Console.Write("Введите K: ");
                K = int.Parse(Console.ReadLine());
                if (K > 0)
                    break;
                else
                    Console.WriteLine("K должно быть > 0");
            }

            StringBuilder str = new StringBuilder();
            bool lastItem = true;
            int countIndex = 0;
            for (int i = A; i < B; i++)
            {
                if (i % K == 0)
                {
                    if (!lastItem)
                    {
                        str.Append(", ");
                    }
                    str.Append(i);
                    countIndex++;
                    lastItem = false;
                }
            }

            string[] subs = str.ToString().Split(',');
            int[] ints = new int[subs.Length];
            int result = 0;

            for (int i = 0; i < subs.Length; i++)
            {
                ints[i] = int.Parse(subs[i].Trim());
                result += ints[i];
            }

            Console.WriteLine();
            Console.WriteLine($"Делимые числа: {str}");
            Console.WriteLine($"Количество чисел: {countIndex}");
            Console.WriteLine($"Сумма чисел: {result}");

        }
        public static void Task2()
        {
            int value = int.Parse(Console.ReadLine());
            int countSteps = 0;
            int maxValue = int.MinValue;
            int intermediateResult = value;

            while (value != 1)
            {
                if (value > 0 && value < 1000)
                {
                    if (value % 2 == 0)
                    {
                        value = value / 2;
                    }
                    else
                    {
                        value = (value * 3) + 1;
                    }
                }
                if (value > maxValue) maxValue = value;
                if (intermediateResult > maxValue) maxValue = intermediateResult;
                countSteps++;
            }

            Console.WriteLine($"Колличество шагов до 1: {countSteps}");

            Console.WriteLine($"Максимальное значение {maxValue}");

        }
        public static void Task1()
        {
            int countInputValue = 0;
            int countUnsatisfactory = 0;
            int countGreat = 0;
            double averageValue = 0;
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;

            while (true)
            {
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out int input))
                {
                    Console.WriteLine("Ошибка: введено не число!");
                    continue;
                }
                else
                {
                    if (input == -1)
                    {
                        break;
                    }
                    else
                    {
                        if (input >= 0 && input <= 100)
                        {
                            if (input < minValue) minValue = input;
                            if (input > maxValue) maxValue = input;
                            if (input < 50) countUnsatisfactory++;
                            if (input >= 90) countGreat++;

                            countInputValue++;
                            averageValue += input;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введено число не попадает в диапазон от 0 до 100");
                        }
                    }
                }
            }

            Console.WriteLine($"Общее количество введённых оценок: {countInputValue}");
            Console.WriteLine($"Средний балл: {Math.Round(averageValue / countInputValue, 2)}");
            Console.WriteLine($"Минимальная оценка {minValue}");
            Console.WriteLine($"Максимальная оценка {maxValue}");
            Console.WriteLine($"Количество оценок неудовлетворительно {countUnsatisfactory}");
            Console.WriteLine($"Колличесвто оценок отлично {countGreat}");
        }

        public static void DisplayUserInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('@', 120));
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
