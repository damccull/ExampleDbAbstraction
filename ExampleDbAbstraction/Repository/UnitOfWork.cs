using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext db;

        //Instantiate a new FlightRepository. This will handle all Flight objects in the database. Here we 'inject' a new List<Flight>.
        IFlightRepository context = new FlightRepository(new List<Flight>());

        public IFlightRepository Flights { get; private set; }
        public IAircraftRepository Aircraft { get; private set; }

        public UnitOfWork(ApplicationDbContext context) {
            this.db = context;
            this.Flights = new FlightRespository(context);
            this.Aircraft = new AircraftRespository(context);
        }

        public int Complete() {
            return db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
