# Ping Pong API Code Challenge

## Requirements

Build a RESTful api in .NET Core that can track ping pong games.  This API needs no authentication, and should be simple and intuitive to call.  It also, does not need to
persist data permanently anywhere (though you can do that if you wish).

Have some fun and complete as much as you feel necessary. We understand if you don't meet
all of the requirements, but the basic requirements that need to be fulfilled
are as follows:

-   Build this API with .NET Core 2.x
-   The following pieces of functionality are required:
    -    The ability to record a new game
    -    The ability to get a list of all games, sorted by date with the newest first
    -    The ability to get list of all games played by a particular user, sorted with the 
         newest first
    -    The ability to get the details of a single game

-   A ping pong game has the following rules and data points (violations of these should not 
    be accepted by the API):
    -    It is played by 2 opposing players
    -    The winner must achieve at least 21 points
    -    The winner must win by 2 points
    -    The date and time of the game is also recorded
    -    There needs to be a unique way to identify a game

-   For simplicity, assume that all players have a unique first name (also assume that this
    name is case-insensitive).

-   While data does not need to be persisted to disk, data successfully added should be 
    returned by a subsequent read operation (as long as the application is not stopped).
    For example, recording a new game should cause that game to come back in a subsequent
    call to list all games.

### Stretch requirements
Here are some additional things you can add if you wish to take this further:

-   Persist the data to disk so it survives a restart of the api (please include everything 
    required to run your application if you do this.)
-   Add automated unit tests for your code.  You could also add code coverage
    and cyclomatic complexity checks.
-   Add API documentation in RAML, Swagger/OpenAPI Spec, or API Blueprint format.
-   Add additional endpoints to complete the CRUD (create, read, update, delete) operations
-   Add some sort of authentication
-   Add the correct things to create a Docker container image to run this project.
    -   Bonus points for using docker to compile the application
    -   Bonus points for using Docker/docker compose to start the application so it can be 
        debugged.

## Project structure

You may use this project as a basis, though that is not required.  This project
may save you a little time, as the following has been set up:

-   `src` - the main location for any "production-ready" applications
     -   `Anow.PingPong.Api` - a skeleton project for the API controllers itself.
-   `test` - the location for automated test projects
     -   `Anow.PingPong.Api.Test` - a holder location for automated tests for the main API 
          project.
-   `Anow.PingPong.sln` - a .sln file that references all projects so that one can simply
    call `dotnet` commands from the root of the project (e.g. `dotnet restore` to restore packages, `dotnet build` to recompile things)

If you wish to use this structure the following commands will get you going right after checkout:

```
dotnet restore
dotnet build
dotnet run --project src/Anow.PingPong.Api
```

This will restore the nuget packages, build the application and then start it (really the only one is necessary, but it suppresses output for the restore and build steps).

Once running you can hit the default  *HealthCheck* endpoint at http://localhost:5000:

```
curl http://localhost:5000
```

or

```
wget -qO- http://localhost:5000
```