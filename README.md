# PtCost

This is a simple asp.net core 3 api project. It has five entities, three of the them are main, and two of them are many to many relationship entities between main entities.
It demonstrates the creating database with entity framework code first, establishes many to many relationships, and seeds database with mock data. 
It has four GET APIs, which read data from database via Entity Framework or Dapper ORM.

### Prerequisites
To debug the project you need

```
Visual Studio 2019
Asp.net Core 3.1.3
.net Core 3.1.3
```

### Debug
After you clone the project to your local, you need to run following commands on Package Manager Console in order to creating database with entity framework.

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```


If you would like to register Dapper ORM after you created database scheme with Entity Framework, you should include following code to your Startup.cs

```c#
services.AddScoped<IRepository, Repository.DapperRepository>(s => new DapperRepository("Data Source = projectSector.db"));
```


and remove the following line
```c#
services.AddDbContext<ProjectDbContext>();
```
```mermaid
  graph TD;
      A-->B;
      A-->C;
      B-->D;
      C-->D;
```
