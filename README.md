# C# ASP.NET Core Practice - Library

The goal of this assignment is meant for me to master ASP.NET Web Application (Model-View-Controller) and to use MVC to create a CRUD application. I have created a tool that keep track of book(s) checked out and returned to the library. 

Throughout this exercise, I have successfully executed several concepts related to ASP.NET Web Application MVC:
- The use of scaffold `Author.cs` model with MVC Controller with Views, using Entity Framework(EF) to create `AuthorController.cs` and **Author Views**. The views scaffolded are `Create.cshtml`, `Delete.cshtml`, `Details.cshtml`, `Edit.cshtml`, and `Index.cshtml`.
- The creation of model context, `LibraryContext.cs` from scratch. I completed and created relational database between **author** and **book** using EF migrations within NuGet Package Manager Console.
- The creation of `BookController.cs` from scratch using empty MVC controller class.
- The creation of **BookController** and `Views()` from scratch using empty controller files. 
- The customization of views within `cshtml` type files. 
- The creation of customized **Exceptions** as `ValidationExceptions.cs`to generate custom **Exception** messages. 
- The use of LINQ to conduct queries. 


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


| Author Table | Book Table |
| ------------- | ------------- |
| ![Author](/References/AuthorTable.PNG) | ![Book](/References/BookTable.PNG) |



## Usage/Approach

- Start the Debugging tool within Visual Studio 2019. 
- A browser will autmatically open to show a view of the database. 

## Screenshots of the views are shown below

| Create View | List View |
| ------------- | ------------- |
| ![CreationView](/References/CreateView.PNG) | ![ListView](/References/ListView.PNG) |

| Details View | Author Index View | 
| ------------- | ------------- |
| ![DetailsView](/References/DetailsView.PNG) | ![AuthorIndex](/References/AuthorIndex.PNG) |

Note: **AuthorController** `Index()` view was created using scaffold, **MVC Controller with Views, using Entity Framework**.





