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
            Drive drive = new Drive(60, 1000);

            drive.DriveTravel(6);
            Console.WriteLine();

            drive.DriveTravel(3);
            Console.WriteLine();

            drive.DriveBackTravel(3);
            drive.PrintLocation();

            drive.DriveTravel(37);
            drive.PrintLocation();

        }
    }
}
