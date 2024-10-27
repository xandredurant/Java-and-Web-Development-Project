Solar Package Web App
This web application allows users to browse and purchase solar packages for home and industrial use. Built with ASP.NET Core and Blazor, it features a product catalog, cart and checkout process, user authentication, and more.

Prerequisites
To set up this application, ensure you have the following installed:

Visual Studio 2022 with the ASP.NET and web development workload and .NET 8 SDK.
SQL Server (e.g., SQL Server Express or Developer Edition) for the database.
SQL Server Management Studio (SSMS) for managing your MSSQL database.

Installation
Follow these steps to set up and run the application locally.

1. Clone the Repository
Clone the repository to your local machine

2. Open the Project in Visual Studio
Open Visual Studio.
Go to File > Open > Project/Solution.
Select the .sln file in the project folder.
3. Configure the Database Connection
In Visual Studio, open the appsettings.json file.

Locate the "DefaultConnection" key in the ConnectionStrings section.

Replace the connection string with your own MSSQL database connection string. It should look something like this:

"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
}

4. Install Dependencies
In the Package Manager Console (PMC), run the following command to restore project dependencies:

"dotnet restore"

5. Set Up the Database
To create the database schema, apply any migrations by running the following command in the NuGet Package Manager Console:

"update-database"

This command applies the Entity Framework Core migrations to set up the database structure.

6. Run the Application
In Visual Studio, set the project as the Startup Project.
Run the project by pressing F5 or selecting Run from the toolbar.
The application should launch in your default web browser, and you can start using it locally.
