# CRUD API - TEST
This CRUD API test, contains a basic scenario with DI under a partial Clean Architecture project architecture. 

The main parts of this project are:

1. In Memory Storage: For practical operation and testing scenario and EF In Memory DB is being used this can be easily switched to another database engine such as SQL Server and MySQL.
2. General Project Structure:
    Controllers
    Define the end points / routes for the web api, controllers are the entry point into the web api from client applications via http requests.

    Models
    Represent request and response models for controller methods, request models define parameters for incoming requests and response models define custom data returned in responses when required. The example only contains request models because it doesn't contain any routes that require custom response models, entities are returned directly by the user GET routes.

    Services
    Contain business logic, validation and database access code.

    Entities
    Represent the application data that is stored in the database.
    Entity Framework Core (EF Core) maps relational data from the database to instances of C# entity objects to be used within the application for data management and CRUD operations.

    Helpers
    Anything that doesn't fit into the above folders.

3. Automapper implementation to route creates and updates invokes.