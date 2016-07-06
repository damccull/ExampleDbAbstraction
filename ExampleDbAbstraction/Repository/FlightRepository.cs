using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    //This class is an implementation of IFlightRepository. It inherits from Repository<Flight> so that it can use all
    //of the general methods available to ALL repos as well as implements any FlightRepository-specific methods.
    //This class should be database-specific. In this case, because of inheritance on Repository<Flight>, it uses an
    //in-memory POCO data structure that stores objects in a List<Flight>.
    public class FlightRepository : Repository<Flight>, IFlightRepository {

        //This property casts the Repository<Flight>'s general Context into a Flight-specific context
        //in order to allow access to methods that may be Flight-specific.
        public List<Flight> FlightContext { get { return Context as List<Flight>; } }

        //This constructor takes in a data store as type List<Flight> and passes it to the parent class
        //of Repository<Flight>
        public FlightRepository(List<Flight> context) : base(context) {
        }

        //Implements the GetTotalHours from IFlightRepository and returns the total hours...
        public float GetTotalHours() {
            float totalHours = 0.0f;
            foreach (var f in this.GetAll()) {
                totalHours += f.Hours;
            }
            return totalHours;
        }
    }
}
