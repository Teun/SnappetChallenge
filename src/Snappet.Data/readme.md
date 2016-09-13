On EF tools (Migrations etc):

How to create the database:

> dotnet ef migrations add MyFirstMigration
> dotnet ef database update

Old Info:

Currently the .NET Core EF does not support targetting a class library project. See: 
https://docs.efproject.net/en/latest/miscellaneous/cli/dotnet.html#targeting-class-library-projects-is-not-supported 

To work around this issue we need to specify our .Web project as the startup project:

> dotnet ef --startup-project ../Snappet.Web/ migrations add MyFirstMigration

or

> dotnet ef --startup-project ../Snappet.Web/ migrations list

Creating:
> dotnet ef --startup-project ../Snappet.Web/ migrations add MyFirstMigration -o "answer.db"
> dotnet ef --startup-project ../Snappet.Web/ database update

Removing:
> dotnet ef --startup-project ../Snappet.Web/ migrations remove --context AnswerContext