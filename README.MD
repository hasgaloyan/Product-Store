### Product Store

This is a simple store application written in .NET Core and AngularJs

## Client
###### dependencies

- AngularJs 1.x (1.6.3)
- jQuery (3.2.0)
- Bootstrap (3.3.7)
- http-server (0.10.0)
- gulp (3.9.1)

##### How to configure and run

Clone this repository and execute the following 
commands in a terminal in the frontend directory:

-  bower install - set up bower dependencies
-  npm install   - set up npm dependencies
-  gulp          - apply styling minificaion
-  http-server   - command runs the project in port 8080





## API
###### dependencies

Install:

NuGet
- Entity Framework Core Command Line Tools: 1.0.0-msbuild1-final
- Microsoft .NET Core Shared Framework Host: 1.1.0
- Microsoft.EntityFrameworkCore.Design:  1.1.2
- Microsoft.EntityFrameworkCore.Sqlite:  1.1.2
- Microsoft.EntityFrameworkCore.Sqlite.Design:  1.1.2
- Microsoft.EntityFrameworkCore.Tools:  1.0.0-msbuild1-final
- Microsoft.EntityFrameworkCore.Tools.Dotnet:  1.0.0-msbuild1-final

SDK

- Microsoft.NETCore.App:  1.1.2


#### Database

To generate the database you must go to the project directory and execute these commands:

- dotnet ef migrations add "InitialMigration"
- dotnet ef database update

Then you can use the test data provided from db/ProductStoreDataOnly.sql to test the project.

To run the project, go to project directory  and execute the command
- dotnet run (by default configuration the api will run on 5000 port)

