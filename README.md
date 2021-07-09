# test
```sh
dotnet tool install -g dotnet-aspnet-codegenerator

dotnet add source/Identity.Service package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add source/Identity.Service package Microsoft.AspNetCore.Identity.UI
dotnet add source/Identity.Service package Microsoft.EntityFrameworkCore.Design
dotnet add source/Identity.Service package Microsoft.EntityFrameworkCore.SqlServer

dotnet aspnet-codegenerator identity -p source/Identity.Service --files "Account.Register"
```

# Additional Resources: 
* [link](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=netcore-cli)# NET-Identity-Server-4
