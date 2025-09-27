using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Driver frirstCar = new Driver(60, 1000);

            // 1000 км
            frirstCar.PrintLocation();
            
            // 1360 км
            frirstCar.Drive(6);
            frirstCar.PrintLocation();

            // 1180 км
            frirstCar.DriveBack(3);
            frirstCar.PrintLocation();

            // Вы в горде №2
            frirstCar.Drive(40);
            frirstCar.PrintLocation();
        }
    }
}
