pushd RndTech.Talks.WebApplicationFactory
docker build -t rnd-tech-waf:dev -f Dockerfile ..
popd
docker run -d -p 5000:80 --name RndTech.Talks.WebApplicationFactory rnd-tech-waf:dev
dotnet test RndTech.Talks.WebApplicationFactory.Tests\RndTech.Talks.WebApplicationFactory.Tests.csproj
docker rm RndTech.Talks.WebApplicationFactory -f