using ExampleDbAbstraction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.POCO.Repository {
    public class AircraftRepository : Repository<Aircraft>, IAircraftRepository {
        public List<Aircraft> FlightContext { get { return Context as List<Aircraft>; } }
        public AircraftRepository(List<Aircraft> context) : base(context) {
        }
    }
}
