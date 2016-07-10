using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext db;

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
