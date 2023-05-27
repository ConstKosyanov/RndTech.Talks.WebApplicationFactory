dotnet build --project RndTech.Talks.WebApplicationFactory\RndTech.Talks.WebApplicationFactory.csproj
start dotnet run --project RndTech.Talks.WebApplicationFactory\RndTech.Talks.WebApplicationFactory.csproj
timeout 3
dotnet test RndTech.Talks.WebApplicationFactory.Tests\RndTech.Talks.WebApplicationFactory.Tests.csproj
taskkill /F /IM RndTech.Talks.WebApplicationFactory.exe