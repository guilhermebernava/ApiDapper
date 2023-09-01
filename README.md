<div align="center">
  <h1>💫 ApiDapper 💫</h1>
  <p><i>A basic API for CRUD operations on PERSONS using Dapper and SQL Server</i></p>
</div>

---

## ⚙️ Prerequisites

Before running this project, make sure you have the following:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio or your preferred IDE
- SQL Server
- Create a database named `DapperDb`
- Create a `PERSONS` table in SQL Server
- Create the `person_get_by_id` stored procedure

## 🚀 Getting Started

### Create the Database

```sql
CREATE DATABASE DapperDb;
```

### Create the Persons Table

```sql
CREATE TABLE [dbo].[Persons] (
  [Id] UNIQUEIDENTIFIER NOT NULL,
  [Name] NVARCHAR(255) NOT NULL,
  [Surname] NVARCHAR(255) NOT NULL,
  [Age] INT NOT NULL,
  [Gender] NVARCHAR(10) NOT NULL,
  [Birthday] DATETIME NOT NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
);
```

### Create the Procedure person_get_by_id

```sql
CREATE PROCEDURE person_get_by_id
  @Id UNIQUEIDENTIFIER
AS
BEGIN
  SELECT * FROM [dbo].[Persons] WHERE [Id] = @Id;
END;
```

After running these SQL commands, update the `DefaultConnection` in `appsettings.json` to your database connection string and then run the API.

## 🛠️ Technologies Used

- .NET 6
- Dapper
- SQL Server
- Repository Pattern
- Stored Procedures
- Clean Code
