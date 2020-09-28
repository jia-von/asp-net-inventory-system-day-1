# C# ASP.NET Core Practice - Library

The goal of this assignment is meant for me to master ASP.NET Web Application and to use ASP.NET WEb API to create a CRUD application. The goal in this assignment is to create an inventory management system which helps company keep track of goods and supplies. As goods and supplies are restocked, sold, or used, the application should update the data appropriately to reflect the changes.

## Summary

I have used `Http` request such as `[HttpGet("API/ShowInventory")]`, `[HttpPost("API/AddProduct")], and `[HttpPut("API/DiscontinueProduct")]` to update and create item for the database. I have used `StatusCode` to validate information and the show user error messages, including customized messages. 

## Installation

```bash
$ git clone https://github.com/jia-von/asp-net-inventory-system-day-1.git
$ cd asp-net-inventory-system-day-1-jia-von
$ cd InventorySystem
$ start devenv InventorySystem.sln
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

The result of successful database migration and update is shown below in [PHPMyAdmin](https://www.phpmyadmin.net/) `localhost` with the database name **mvc_inventory**.

![table](/ScreenShots/table.PNG)

## Usage/Approach

- Start the Debugging tool within Visual Studio 2019. 
- A browser will autmatically open to show a view of the database. 
- Use the [Postman](https://www.postman.com/) to use the program. 

## Screenshots of the views are shown below

| AddProduct | AddQuantityProduct |
| ------------- | ------------- |
| ![AddProduct](/ScreenShots/AddProduct.PNG) | ![AddQuantityProduct](/ScreenShots/AddQuantityProduct.PNG) |

| DiscontinueProduct | ShowInventory | SubtractedQuantityProduct |
| ------------- | ------------- | ------------- |
| ![DiscontinueProduct](/ScreenShots/DiscontinueProduct.PNG) | ![ShowInventory](/ScreenShots/ShowInventory.PNG) | ![SubtractedQuantityProduct](/ScreenShots/SubtractedQuantityProductPNG.PNG) |







