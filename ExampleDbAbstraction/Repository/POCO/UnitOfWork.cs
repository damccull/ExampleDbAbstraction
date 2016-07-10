using ExampleDbAbstraction.POCO.Repository;
using ExampleDbAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.POCO.Repository {
    public class UnitOfWork : IUnitOfWork {

        public IFlightRepository Flights { get; private set; }
        public IAircraftRepository Aircraft { get; private set; }

        public UnitOfWork() {
            //Here we instantiate these repos manually but we could inject them through constructor arguments if desired.
            //See the MySql example for how to do it with a single db context.
            this.Flights = new FlightRepository(new List<Flight>());
            this.Aircraft = new AircraftRepository(new List<Aircraft>());
        }

        public int Save() {
            //"POCO has no transactional capability. All changes are instant. Be careful."
            return 0;
        }

        public void Dispose() {
            //"POCO has no transactional capability. All changes are instant. Be careful."
        }
    }
}
