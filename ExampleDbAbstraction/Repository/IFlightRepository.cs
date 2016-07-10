using ExampleDbAbstraction.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    //This interface represents a repository for Flight objects. It inherits from the IRepository generic
    //interface, passing in a type of Flight, which is the type this repo deals with.
    //This interface contains method definitions that deal specifically with flights, rather than with all classes.
    //Implement this interface in separate class.
    public interface IFlightRepository : IRepository<Flight> {
        //This method is only applicable to Flight objects, so it is defined here rather than in Repository.
        float GetTotalHours();

        IEnumerable<Flight> FindByRoutePoint(string routePoint);
    }
}
