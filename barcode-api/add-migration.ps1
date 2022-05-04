$migrationName = Read-Host "Migration name"
dotnet dotnet-ef migrations add --project .\Barcode.DAL\ --startup-project .\Barcode.API\ $migrationName