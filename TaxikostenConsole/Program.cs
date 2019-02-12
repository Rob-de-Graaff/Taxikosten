using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaxikostenConsole
{
    class Program
    {
        //private static int distance;// travel distance
        //private static int time;// travel time
        //private static DateTime currentDate;
        //private static DateTime currentTime;
        //private static double TaxiFare = 0.0;
        //private static bool addition = false;

        static void Main(string[] args)
        {
            int distance;// travel distance
            int time;// travel time
            DateTime currentDate;
            DateTime currentTime;
            double TaxiFare = 0.0;
            bool addition = false;

            while (true)
            {
                Console.WriteLine("Set travel distance in km");
                if (int.TryParse(Console.ReadLine(), out distance))
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Set travel time in minutes");
                if (int.TryParse(Console.ReadLine(), out time))
                {
                    break;
                }
            }

            currentDate = DateTime.Today;//new DateTime(2019,1,12);
            currentTime = DateTime.Now;
            TimeSpan start;
            TimeSpan end;

            switch (currentDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    start = new TimeSpan(00, 0, 0);
                    end = new TimeSpan(7, 0, 0);
                    if ((currentTime.TimeOfDay > start) && (currentTime.TimeOfDay < end))
                    {
                        addition = true;
                    }
                    break;
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                    addition = false;
                    break;
                case DayOfWeek.Friday:
                    start = new TimeSpan(22, 0, 0);
                    end = new TimeSpan(00, 0, 0);
                    if ((currentTime.TimeOfDay > start) && (currentTime.TimeOfDay < end))
                    {
                        addition = true;
                    }
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    addition = true;
                    break;
            }

            TaxiFare = CalculatePrice(distance, time, currentDate, currentTime, addition);

            Console.WriteLine($"day: {currentDate.DayOfWeek} time: {currentTime.TimeOfDay} price: {TaxiFare:0.00}");
            Console.ReadLine();
        }

        private static double CalculatePrice(int distance, int travelTime, DateTime date, DateTime time, bool boolAddition)
        {
            double cabFare;
            cabFare = 1 * distance;
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(18, 0, 0);
            if ((time.TimeOfDay > start) && (time.TimeOfDay < end))
            {
                cabFare = cabFare + 0.25 * travelTime;
            }
            else
            {
                cabFare = cabFare + 0.45 * travelTime;
            }

            if (boolAddition)
            {
                cabFare *= 1.15;
            }
            
            return Math.Round(cabFare, 2);
        }
    }
}
