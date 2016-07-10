using ExampleDbAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction {
    class Program {
        static void Main(string[] args) {


            

            //This demo lists ALL the flights in the data store.
            Caption("GetAll()");
            foreach (var flight in context.GetAll()) {
                Console.WriteLine(flight);
            }

            //This demo lists all the flights in the data store that match the predicate.
            Caption($"{Environment.NewLine}Find(f => f.Route.Contains(\"KDEN\"))");
            foreach (var f in context.Find(f => f.Route.Contains("KDEN"))) {
                Console.WriteLine(f);
            }

            //This demo retrieves a specific flight by id.
            Caption($"{Environment.NewLine}Get(2)");
            var gotFlight = context.Get(2);
            Console.WriteLine(gotFlight);

            //This demo removes the flight retrieved in the previous demo from the data store.
            Caption($"{Environment.NewLine}Remove(gotFlight) This removes the flight from the Get(2) example above.");
            context.Remove(gotFlight);

            //This demo lists ALL the flights in the data store again to show the missing flight removed in the previos demo.
            Caption($"{Environment.NewLine}GetAll() again to demonstrate Remove(). Note ID 2 missing.");
            foreach (var flight in context.GetAll()) { 
                Console.WriteLine(flight);
            }

            //This demo shows the FlightRepository specific method GetTotalHours, which adds up all the hours
            //from each flight and prints the total.
            Caption($"{Environment.NewLine}GetTotalHours() shows total hours AFTER removing flight 2");
            Console.WriteLine($"Total Hours Flown: {context.GetTotalHours().ToString("N1")}");

            Caption($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prints text in yellow to differentiate between captions and output.
        /// </summary>
        /// <param name="text">The caption text</param>
        private static void Caption(string text) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
