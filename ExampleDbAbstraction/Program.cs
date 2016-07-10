using ExampleDbAbstraction.POCO.Repository;
using ExampleDbAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction {
    class Program {
        static void Main(string[] args) {

            //Here we specifically instantiate a particular implementation. It's appropriate here because you have to
            //instantiate it at some point in the set up of your program or you'll never have a storage layer.
            // NOTE: A unit of work should only be used for a single transaction to the storage layer, so this implementation
            // could cause problems if you have to instantiate this all over the place in your app. A better approach
            // would be to instantiate this ONE time in an Inversion of Control container like https://autofac.org/
            // and then ask autofac for an instance of the unit of work every time you need one. It will hand you
            // a new instance of the appropriate type, and you never instantiate it at all. This allows you to
            // decouple the UnitOfWork class from your code almost entirely, because the rest of your code only depends on
            // IUnitOfWork.
            var context = new UnitOfWork();
            DatabasePopulator.Populate(context);

            //This demo lists ALL the flights in the data store.
            Caption("GetAll()");
            foreach (var flight in context.Flights.GetAll()) {
                Console.WriteLine($"{flight}\t{context.Aircraft.Get(flight.AircraftId)}");
            }

            //This demo lists all the flights in the data store that match the predicate.
            Caption($"{Environment.NewLine}FindByRoutePoint(\"KDEN\")");
            foreach (var f in context.Flights.FindByRoutePoint("KDEN")) {
                Console.WriteLine($"{f}\t{context.Aircraft.Get(f.AircraftId)}");
            }

            //This demo retrieves a specific flight by id.
            Caption($"{Environment.NewLine}Get(2)");
            var gotFlight = context.Flights.Get(2);
            Console.WriteLine($"{gotFlight}\t{context.Aircraft.Get(gotFlight.AircraftId)}");

            //This demo removes the flight retrieved in the previous demo from the data store.
            Caption($"{Environment.NewLine}Remove(gotFlight) This removes the flight from the Get(2) example above.");
            context.Flights.Remove(gotFlight);

            //This demo lists ALL the flights in the data store again to show the missing flight removed in the previos demo.
            Caption($"{Environment.NewLine}GetAll() again to demonstrate Remove(). Note ID 2 missing.");
            foreach (var flight in context.Flights.GetAll()) {
                Console.WriteLine($"{flight}\t{context.Aircraft.Get(flight.AircraftId)}");
            }

            //This demo shows the FlightRepository specific method GetTotalHours, which adds up all the hours
            //from each flight and prints the total.
            Caption($"{Environment.NewLine}GetTotalHours() shows total hours AFTER removing flight 2");
            Console.WriteLine($"Total Hours Flown: {context.Flights.GetTotalHours().ToString("N1")}");

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
