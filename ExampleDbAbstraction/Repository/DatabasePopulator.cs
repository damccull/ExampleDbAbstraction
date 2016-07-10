using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public static class DatabasePopulator {

        public static void Populate(IUnitOfWork work) {
            PopulateAircraft(work);
            PopulateFlights(work);
        }

        private static void PopulateFlights(IUnitOfWork work) {
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

            //Get all aircraft
            var aircraft = work.Aircraft.GetAll().ToList();

            //Create 10 flights with random routes and hours flown
            for (int i = 0; i < 10; i++) {
                var flight = new Flight {
                    Id = i + 1,
                    Route = routes[rand.Next(routes.Count)],
                    Hours = Convert.ToSingle(rand.Next(8) + rand.NextDouble()),
                    AircraftId = aircraft[rand.Next(aircraft.Count)].Id
                };
                //Add the flight to the data store

                work.Flights.Add(flight);
            }
        }

        private static void PopulateAircraft(IUnitOfWork work) {
            List<string> aircraft = new List<string> {
                "Cessna 172M",
                "Cessna 172S",
                "Mooney M20",
                "Raptor",
                "Sirrus SR-20"
            };

            var rand = new Random();

            for (int i = 0; i < aircraft.Count; i++) {
                work.Aircraft.Add(new Aircraft {
                    Id = i + 1,
                    Model = aircraft[rand.Next(aircraft.Count)],
                    TailNumber = TailNumberGenerator()
                });
            }
        }

        private static string TailNumberGenerator() {

            var rand = new Random();
            var tailnumber = new StringBuilder();
            tailnumber.Append("N");

            var numCharsInTailNumber = rand.Next(1, 5);
            var numLettersInTailNumber = rand.Next(3);
            if (numLettersInTailNumber >= numCharsInTailNumber) {
                numLettersInTailNumber = numCharsInTailNumber - 1;
            }


            for (int i = 0; i <= numCharsInTailNumber; i++) {

                var numToAppend = rand.Next(10);

                if (i == 0 && numToAppend == 0) {
                    numToAppend++;
                }
                tailnumber.Append(numToAppend.ToString());

                if (i >= numCharsInTailNumber - (numLettersInTailNumber)) {
                    var tailLetter = (char)('A' + rand.Next(26));
                    if (tailLetter == 'O' || tailLetter == 'I') {
                        tailLetter = (char)(tailLetter + 1);
                    }
                    tailnumber.Remove(i + 1, 1);
                    tailnumber.Insert(i + 1, tailLetter);
                }
            }

            return tailnumber.ToString();
        }
    }
}
