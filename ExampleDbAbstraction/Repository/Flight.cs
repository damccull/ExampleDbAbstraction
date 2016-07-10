using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    //This class is an in-memory representation of a Flight record from a data store.
    public class Flight {
        public int Id { get; set; }
        public string Route { get; set; }
        public float Hours { get; set; }
        public int AircraftId { get; set; }

        public override string ToString() {
            return $"ID: {Id}\tROUTE: {Route}\tHOURS {Hours.ToString("N1")}";
        }
    }
}
