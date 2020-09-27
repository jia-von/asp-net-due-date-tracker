# C# ASP.NET Core Practice - Library

The goal of this assignment is meant for me to master ASP.NET Web Application (Model-View-Controller) and to use MVC to create a CRUD application. I have created a tool that kepp track of book checked out and returned to the library. 

## Installation

- Use the NuGet Package Manager install packages Entity Framework [ASP.NET Core](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli).
- Second package to install is [Pomelo Entity Framework Core](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) provider. 

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySQL
```

## Usage/Approach

- The database was populated in [PHPMyAdmin](https://www.phpmyadmin.net/) using a SQL script. The database is named *existing_db_practice*.
- The database contains two tables *Person* and *PhoneNumber*.
- A *PersonContext* model was created and configured to target models *Person* and *PhoneNumber* and the relational database. 
- A simple program was written to take the first name from the user and then to pring the full name of the user from the database. 
