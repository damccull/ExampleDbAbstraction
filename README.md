# ExampleDbAbstraction

This project demonstrates how to use the Repository pattern to abstract away database-specific implementation.

This demo uses an in-memory POCO data store as the implementation. In order to change the data store, a developer must simply
implement the IRepository and IFlightRepository interfaces with code specific to the database of choice.

The Program.cs only references the IFlightRepository (which in turn references IRepository), so the implementation classes can change
without affecting the Program.cs file at all.
