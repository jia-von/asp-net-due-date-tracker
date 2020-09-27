# C# ASP.NET Core Practice - Library

The goal of this assignment is meant for me to master ASP.NET Web Application (Model-View-Controller) and to use MVC to create a CRUD application. I have created a tool that keep track of book(s) checked out and returned to the library. 

## Installation

```bash
$ git clone https://github.com/jia-von/asp-net-due-date-tracker.git
$ cd asp-net-library-due-date-tracker-day-1-jia-von
$ cd Library
$ start devenv Library.sln
```

Use the NuGet Package Manager to install packages:
- Entity Framework [ASP.NET Core Design](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli).
- Entity Framework [Pomelo Entity Framework Core](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql). 
- Entity Framework [ASP.Net Core SqlServer](https://docs.microsoft.com/en-us/ef/core/).

```bash
PM> dotnet add package Microsoft.EntityFrameworkCore.Design
PM> dotnet add package Pomelo.EntityFrameworkCore.MySQL
PM> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

Initiate initial migration to create a database with data seeded.

```bash
PM> dotnet ef migrations add InitialCreation
PM> dotnet ef update database
```
The result of successful database migration and update is shown below in [PHPMyAdmin](https://www.phpmyadmin.net/) `localhost` with the database name **mvc_library**. 

![DataBase](/References/DataBase.PNG)


The **author** table:

![Author](/References/AuthorTable.PNG)


The **book** table:

![Book](/References/BookTable.PNG)

## Usage/Approach

- Start the Debugging tool within Visual Studio 2019. 
- A browser will autmatically open to show a view of the database. 

## Screenshots of the views are shown below

Create view through **BookController**:

![CreationView](/References/CreateView.PNG)


List view through **BookController**:

![ListView](/References/ListView.PNG)


Detail view through **BookController**:

![DetailsView](/References/DetailsView.PNG)


Index view through **AuthorController* created using scaffold, MVC Controller with Views, using Entity Framework:

![AuthorIndex](/References/AuthorIndex.PNG)


## Summary
