using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public static class DatabasePopulator {
        public static void Populate(IUnitOfWork work) {

            //Some basic flight routes
            List<string> routes = new List<string> {
                "KLAX - KLAX",
                "KDEN - KLAX",
                "KDEN - KATL",
                "KATL - KDEN",
                "KJFK - KDEN"
            };
            //Create a random number generator.
            var rand = new Random();

            //Create 10 flights with random routes and hours flown
            for (int i = 0; i < 10; i++) {
                var flight = new Flight {
                    Id = i + 1,
                    Route = routes[rand.Next(routes.Count)],
                    Hours = Convert.ToSingle(rand.Next(8) + rand.NextDouble())
                };
                //Add the flight to the data store
                
                work.Flights.Add(flight);
            }
        }
    }
}
