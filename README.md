## Team Project Weather Backend

This repository contains the backend code for the Team Project Weather app, developed for your class. The app provides weather information for different cities around the world and helps users to determine the best location and time of year to plant certain crops.

### Technologies Used

The backend of this project is built on the following technologies:
- .NET Framework
- C#
- SQL Server
- Swagger

### Setup

To run the backend of this project, follow the steps below:
1. Clone the repository to your local machine
2. Open the project in Microsoft Visual Studio
3. Create a new SQL Server database and update the connection string in the `appsettings.json` file to point to the newly created database
4. Build the project to restore the NuGet packages and build the solution
5. Press the F5 key to start debugging the project
6. The project will run in the default browser and open the Swagger UI

### API Endpoints

The following API endpoints are available:
- `GET /api/weather/{city}`: Retrieves weather information for the specified city
- `GET /api/cities`: Retrieves a list of all cities in the database
- `POST /api/cities`: Adds a new city to the database

### Learn More

To learn more about .NET Framework, C#, SQL Server and Swagger, check out the following resources:
- [.NET Framework documentation](https://docs.microsoft.com/en-us/dotnet/framework/)
- [C# documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [SQL Server documentation](https://docs.microsoft.com/en-us/sql/?view=sql-server-ver15)
- [Swagger documentation](https://swagger.io/docs/)
