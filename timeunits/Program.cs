using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace timeunits
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Note: 1 year = 365.2425 days and 1 month = 30.436875 days.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                //initializes array for time units and their times in milliseconds
                string[] times = { "ms", "sec", "min", "hr", "d", "w", "mo", "yr", "dec", "c", "mi" };
                BigInteger[] times_ms = {1, 1000, 60000, 3600000, 86400000, 604800000, 2629746000, 31556952000, 315569520000, 3155695200000, 31556952000000};
                Console.WriteLine("millisecond, second, minute, hour, day, week, month, year, decade, century, millennium");
                Console.WriteLine("[ms, sec, min, hr, d, w, mo, yr, dec, c, mi]");
                Console.WriteLine("Enter desired unit of measurement from the list above: ");
                string unitresponse = Console.ReadLine();
                while (!(times.Contains(unitresponse.ToLower())))
                {
                    if (!(times.Contains(unitresponse.ToLower())))
                    {
                        Console.WriteLine("Sorry, but you'll have to type that again. Use the abbreviated forms (e.g. ms)");
                        unitresponse = Console.ReadLine();
                    }

                }
                timeinput:
                Console.WriteLine("Enter desired amount of time (" + unitresponse + "): ");
                string timeresponse = Console.ReadLine();
                bool oneofem = false;
                //if input is decimal, negative or thousand separated, do not accept value
                //TODO: Actually make the user able to input these
                if (timeresponse.Contains("."))
                {
                    Console.WriteLine("Sorry, decimals are not accepted.");
                    oneofem = true;
                }
                if (timeresponse.Contains(","))
                {
                    Console.WriteLine("Sorry, thousands separators are not properly implemented yet.");
                    oneofem = true;
                }
                if (timeresponse.Contains("-"))
                {
                    Console.WriteLine("Sorry, negative amounts aren't handled by the program.");
                    oneofem = true;
                }
                if (oneofem == true)
                {
                    goto timeinput;
                }
                try { 
                    Convert.ToInt64(timeresponse); 
                } catch (System.FormatException)
                {
                    Console.WriteLine("Input is not a number! try again.");
                    goto timeinput;
                } catch (System.OverflowException)
                {
                    Console.WriteLine("Input is too large! Are you sure you don't want to use a bigger unit of measurement?");
                    goto timeinput;
                }
                long timedresponse = Convert.ToInt64(timeresponse);
                BigInteger actualtimems = new BigInteger(0);
                //Converts the time the user inputted in their unit of measurement in milliseconds
                switch(unitresponse)
                {
                    case "ms":
                        actualtimems = timedresponse * 1;
                        break;
                    case "sec":
                        actualtimems = timedresponse * 1000;
                        break;
                    case "min":
                        actualtimems = timedresponse * 60000;
                        break;
                    case "hr":
                        actualtimems = timedresponse * 3600000;
                        break;
                    case "d":
                        actualtimems = timedresponse * 86400000;
                        break;
                    case "w":
                        actualtimems = timedresponse * 604800000;
                        break;
                    case "mo":
                        actualtimems = timedresponse * 2629746000;
                        break;
                    case "yr":
                        actualtimems = timedresponse * 31556952000;
                        break;
                    case "dec":
                        actualtimems = timedresponse * 315569520000;
                        break;
                    case "c":
                        actualtimems = timedresponse * 3155695200000;
                        break;
                    case "mi":
                        actualtimems = timedresponse * 31556952000000;
                        break;
                }
                for (int i = 10; i >= 0; i--)
                {
                    //divides the user inputted time (in ms) by the time in ms of each unit of measurement
                    BigInteger value = actualtimems / times_ms[i];
                    long paul = 0; //did I really name this "paul" lol? well I'm leaving it like that
                    //basically gets the remainder of the division, which is then used to calculate the remaining time into the lower units of measurement
                    //(otherwise it'd just convert the time into each unit of measurement instead of actually splitting the time between them)
                    //couldn't really get it to work with a regular mod operator
                    while (paul < value)
                    {
                        actualtimems = actualtimems - times_ms[i];
                        paul++;
                    }
                    Console.WriteLine(value + " " + times[i]);

                }
            }



        }
    }
}
