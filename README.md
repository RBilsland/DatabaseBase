# DatabaseBase

This is a very basic C# solution to show an example of implementing a database access layer. A few things to note are as follows;
- This project is targetting .NET Core 3.1 (LTS) so as a consiquence the additional packages referenced are the appropriate versions too (v5.0.13). If I was targetting .Net 6 then the additional packages would be using different versions too (v6.?).
- While the MyApplication.Core project includes the Microsoft.EntityFrameworkCore and Microsoft.EntityFrameworkCore.SqlServer packages the MyApplication.UI project includes the Microsoft.EntityFrameworkCore.Tools package. These are seperated because the Core project requires the access libraries while the UI project is where you run the Package Manager Console database commands from.
- This solution is using the *Code First* approach to database design.
- Once the solution is downloaded then an empty database called Demo must be created on your local SQL Server instance.
- If the solution is building cleanly then open the Package Manager Console (Tools, NuGet Package Manager, Package Manager Console) and
  - Run `add-migration CreateExampleTable` to create the database migration files for the included Example table.
  - Run `update-database` to deploy the Example table to the Demo database.
  - **NOTE** - an explanation of the commands can be found at https://www.entityframeworktutorial.net/efcore/pmc-commands-for-ef-core-migration.aspx
- Running the solution should present a single Server Side Blazor page containing a welcome message and the single row from the Example table.

## An Explination Of Whats Happening

- The Core project contains the DbContext to access the Demo database and any associated Models.
- These are organised in a logical manner with everything to do with data in the Data folder, that contains a Demo folder for the Demo database access, this contains the DemoDbContext class and a Models folder for the database table models.
