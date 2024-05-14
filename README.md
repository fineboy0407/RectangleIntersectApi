# Rectangle Intersection Web API
Simple .NET 6 based web api service designed to determine intersections between predefined rectangles and a provided line segment. 
This API is structured using a layered architecture, promoting separation of concerns and making the codebase scalable and maintainable.

## Features
- Fetch Intersections: Allows fetching all rectangles that intersect with a given line segment.
- Entity Framework Core: Leverage EF Core for efficient data handling with SQL Server.
- Layered Architecture: Ensures clean architecture principles are followed, segregating business logic from the web layer.
- Testing : Validate the web api with unit and integration tests.

## Getting Started
### Prerequisites
- .NET 6 SDK
- Visual Studio 2022 (recommended) or another compatible IDE with C# support.
- SQL Server (LocalDB or your preferred SQL Server setup)

### Installation
1. Clone the repository <br>
``https://github.com/fineboy0407/RectangleIntersectApi.git`` <br>
``cd RectangleIntersectionSolution`` <br>

2. Restore NuGet packages <br>
``dotnet restore`` <br>

3. Set up the database <br>
Make sure your connection strings in appsettings.json inside RectangleIntersectionWebApi are correct as per your SQL Server configuration.

Run the following command to apply migrations:

``cd RectangleIntersectionWebApi`` <br>
``dotnet ef database update`` <br>

### Running the application
From the command line:

``cd RectangleIntersectionWebApi`` <br>
``dotnet run`` <br>
This will start the application on a default port (usually https://localhost:5001 and http://localhost:5000). The endpoints can be accessed via these URLs.

### Using the API
- Get Intersecting Rectangles
Endpoint: GET ``/api/rectangles/intersect``

Request parameters: ``x1``, ``y1``, ``x2``, ``y2`` (coordinates of the line segment) <br>

Example using curl: <br>

``curl -X GET "https://localhost:5001/api/rectangles/intersect?x1=0&y1=0&x2=10&y2=10"`` <br>
This request will return JSON data containing rectangles that intersect with the line segment defined by x1, y1, x2, y2.

## Development
### Building
To build the project for development, run: <br>

``dotnet build``

### Testing
Automated tests are set up using xUnit for both unit testing and integration testing.
 
To run tests, execute:

``cd RectangleIntersectionWebApi.Tests`` <br>
``dotnet test`` <br>
This will run the configured unit and integration tests, ensuring the service logic is functioning as expected.

## Contact
``fineboy0407``

Project Link: https://github.com/fineboy0407/RectangleIntersectApi
