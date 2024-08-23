dotnet ef migrations add InitialData --context EntityDbContext --project C:\Users\achak\Documents\projects\test-dotnet-app\test-dotnet-app.csproj --verbose

dotnet ef migrations add FirstMigration --context EntityDbContext -o Migrations --verbose

dotnet ef database update [migrationName] // defaults to last migration name

dotnet ef migrations list

dotnet ef migrations remove