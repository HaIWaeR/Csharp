using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nИгра 1");
            Lotto loto1 = new Lotto();
            for (int i = 0; i < 50; i++)
            {
                int temporaryProvisioForInspection = loto1.GetNumber();
                Console.Write($"{temporaryProvisioForInspection} ");
                if (temporaryProvisioForInspection == -1)
                    break;
            }

            Console.WriteLine("\n\nИгра 2");
            Lotto loto2 = new Lotto();
            for (int i = 0; i < 50; i++)
            {
                int temporaryProvisioForInspection = loto2.GetNumber();
                Console.Write($"{temporaryProvisioForInspection} ");
                if (temporaryProvisioForInspection == -1)
                    break;
            }

            Console.WriteLine("\n\nИгра 3");
            Lotto loto3 = new Lotto();
            for (int i = 0; i < 50; i++)
            {
                int temporaryProvisioForInspection = loto3.GetNumber();
                Console.Write($"{temporaryProvisioForInspection} ");
                if (temporaryProvisioForInspection == -1)
                    break;
            }

            Console.WriteLine("\n\nИгра 4");
            Lotto loto4 = new Lotto();
            for (int i = 0; i < 50; i++)
            {
                int temporaryProvisioForInspection = loto4.GetNumber();
                Console.Write($"{temporaryProvisioForInspection} ");
                if (temporaryProvisioForInspection == -1)
                    break;
            }

            Console.WriteLine("\n\nИгра 5");
            Lotto loto5 = new Lotto();
            for (int i = 0; i < 110; i++)
            {
                int temporaryProvisioForInspection = loto5.GetNumber();
                Console.Write($"{temporaryProvisioForInspection} ");
                if (temporaryProvisioForInspection == -1)
                    break;
            }

            Lotto.PrintGamesStats();
        }
    }

    class Lotto
    {
        private List<int> lossHistory = new List<int>();
        private static Random rnd = new Random();
        private int numberOfGames = 99;
        private static Dictionary<int, int> numberStatistics = new Dictionary<int, int>();

        public int GetNumber()
        {
            if (lossHistory.Count >= numberOfGames)
            {
                Console.Write("\nВ диапазоне нехватает чисел: ");
                return -1;
            }

            int returnNumber;

            do
            {
                returnNumber = rnd.Next(1, 100);
            }
            while (lossHistory.Contains(returnNumber)) ;
            lossHistory.Add(returnNumber);

            if (numberStatistics.ContainsKey(returnNumber))
                numberStatistics[returnNumber]++;
            else
                numberStatistics[returnNumber] = 1; 
            return returnNumber;


        }

        public static void PrintGamesStats()
        {
            if (numberStatistics.Count == 0)
            {
                Console.WriteLine("Числа еще не выпадали");
                return;
            }

            List<int> sortedKeys = new List<int>(numberStatistics.Keys);
            sortedKeys.Sort();

            Console.WriteLine();
            foreach (int key in sortedKeys)
            {
                Console.WriteLine($"Число {key}: выпало {numberStatistics[key]} раз");
            }
        }
    }
}
