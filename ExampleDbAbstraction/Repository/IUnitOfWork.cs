using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDbAbstraction.Repository {
    public interface IUnitOfWork : IDisposable {
        IFlightRepository Flights { get; }
        IAircraftRepository Aircraft { get; }
        int Save();
    }
}
