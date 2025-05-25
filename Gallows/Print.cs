using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visilica
{
    internal class Print
    {
        public void HoverNumbers(int count)
        {
            Print loss = new Print();

            switch (count)
            {
                case 1:
                    loss.PositionBeginning();
                    break;
                case 2:
                    loss.PositionHead();
                    break;
                case 3:
                    loss.PositionTorso();
                    break;
                case 4:
                    loss.PositionRightHand();
                    break;
                case 5:
                    loss.PositionLeftHand();
                    break;
                case 6:
                    loss.PositionRightFoot();
                    break;
                case 7:
                    loss.PositionLeftFoot();
                    break;
            }
        }

        // 1
        private void PositionBeginning()
        {
            string? line; 
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover1.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }

        // 2 
        private void PositionHead()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover2.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }

        // 3
        private void PositionTorso()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover3.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }

        // 4
        private void PositionRightHand()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover4.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }

        // 5 
        private void PositionLeftHand()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover5.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }

        // 6
        private void PositionRightFoot()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover6.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }
        // 7 
        private void PositionLeftFoot()
        {
            string? line;
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\vital\\source\\repos\\visilica\\visilica\\Hover\\Hover7.txt"))
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
        }
    }
}
