using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drive
{
    internal class Driver
    {
        private int AverageСarSpeed;
        private int CarСoordinate;
        private double TechnicalCondition = 100;

        public int StartСityN1 = 1010;
        public int EndСityN1 = 1020;
        
        public int StartСityN2 = 3565;
        public int EndСityN2 = 3580;
        
        public int StartСityN3 = -2500;
        public int EndСityN3 = -2530;


        public void Drive(int travelTime)
        {
            if (TechnicalCondition > 0)
            {
                CarСoordinate += travelTime * AverageСarSpeed;
                TechnicalCondition += -0.01 * ((AverageСarSpeed * travelTime) / 100);
            }
            else
               Console.WriteLine("Машина мертва!");
        }

        public void DriveBack(int travelTime)
        {
            if (TechnicalCondition > 0)
            {
                CarСoordinate -= travelTime * AverageСarSpeed;
                TechnicalCondition += -0.01 * ((AverageСarSpeed * travelTime) / 100);
            }
            else
                Console.WriteLine("Машина мертва!");
        }

        public void PrintLocation()
        {
            Console.WriteLine();
            if (CarСoordinate >= StartСityN1 && CarСoordinate <= EndСityN1)
            {
                Console.WriteLine("Вы в городе N1");
                return;
            }

            if (CarСoordinate >= StartСityN2 && CarСoordinate <= EndСityN2)
            {
                Console.WriteLine("Вы в городе N2");
                return;
            }

            if (CarСoordinate >= StartСityN3 && CarСoordinate <= EndСityN3)
            {
                Console.WriteLine("Вы в городе N3");
                return;
            }
            Console.WriteLine($"Вы находитесь на трассе на {CarСoordinate} километре ");
            Console.WriteLine();
        }
        public Driver(int averageСarSpeed, int carСoordinate)
        {
            AverageСarSpeed = averageСarSpeed;
            CarСoordinate = carСoordinate;
        }
    }
}
