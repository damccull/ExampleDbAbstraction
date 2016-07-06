# ExampleDbAbstraction

This project demonstrates how to use the Repository pattern to abstract away database-specific implementation.

This demo uses an in-memory POCO data store as the implementation. In order to change the data store, a developer must simply implement the IRepository and IFlightRepository interfaces with code specific to the database of choice. For instance, to use MySql, a developer would replace Repository.cs and FlightRepository.cs with versions that call into MySql queries instead of the in-memory POCO implementation that currently exists.

The Program.cs only references the IFlightRepository (which in turn references IRepository), so the implementation classes can change without affecting the Program.cs file at all.
