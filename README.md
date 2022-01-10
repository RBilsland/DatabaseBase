# DatabaseBase

This is a very basic C# solution to show an example of implementing a database access layer. A few things to note are as follows;
- This project is targetting .NET Core 3.1 (LTS) so as a consiquence the additional packages referenced are the appropriate versions too (v5.0.13). If I was targetting .Net 6 then the additional packages would be using different versions too (v6.?).
- While the MyApplication.Core project includes the Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.SqlServer packages the MyApplication.UI project includes the Microsoft.EntityFrameworkCore.Tools package. These are seperated because the Core project requires the access libraries while the UI project is where you run the Package Manager Console database commands from.
- This solution is using the *Code First* approach to database design.
- Once the solution is downloaded then an empty database called Demo must be created on your local SQL Server instance.
- If the solution is building cleanly then open the Package Manager Console (Tools, NuGet Package Manager, Package Manager Console), change the default project at the top of the Package Manager Console window to MyApplication.Core and double check that the Startup Project in the Solution Explorer windows is the MyApplication.UI project. Then...
  - Run `add-migration CreateExampleTable` to create the database migration files for the included Example table.
  - Run `update-database` to deploy the Example table to the Demo database.
  - **NOTE** - an explanation of the commands can be found at https://www.entityframeworktutorial.net/efcore/pmc-commands-for-ef-core-migration.aspx
- Running the solution should present a single Server Side Blazor page containing a welcome message and the single row from the Example table.

## An Explination Of Whats Happening

- The Core project contains the DbContext to access the Demo database and any associated Models.
- These are organised in a logical manner with everything to do with data in the Data folder, that contains a Demo folder for the Demo database access, this contains the DemoDbContext class and a Models folder for the database table models.
- Inside the DemoDbContext there is the Public Virtual definition for the Example table and the rows in the OnModelCreating method that references the Example table, defines it's index and also inserts seed data.
- If you are looking to link tables together (Primary / Foreign Key) then I suggest using data annotations. A number of use cases are discussed here https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
- The Example model doesn't contain much, just an Id and a Description but does contain the data annotations to setup a primary key.
- The UI project contains the usage of the Core project and as such it is a dependancy to the UI project.
- In Startup the DemoDbContext service is added and a using to MyApplication.Core.Data.Demo is included so that the DbContext class can be found.
- It is in the definition of the DemoDbContext service that the AppSettings.json is retrieved to point at the Demo database.
- It is in the index code behind page (Pages/Index.razor.cs) that a private reference to the DemoDbContext is Injected and in the pages OnInitialized method that it is used to retrieve all the rows from the Example table into a public list variable. Again appropriate Usings are included to .Demo and .Demo.Models so that calsses can be found.
- In the index page itself the public list variable is iterated through to display any results.
