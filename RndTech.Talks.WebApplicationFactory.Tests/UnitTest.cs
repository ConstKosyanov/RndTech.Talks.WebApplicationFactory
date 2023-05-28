using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RndTech.Talks.WebApplicationFactory.Tests;

public class UnitTest : IClassFixture<HostFixture>
{
	[Fact]
	public async Task PingTest()
	{
		var client = new HttpClient();
		Assert.Equal("working", await client.GetStringAsync("http://localhost:5000/ping"));
	}
}

public class HostFixture : IAsyncDisposable
{
	private readonly WebApplication app;

	public HostFixture()
	{
		var builder = WebApplication.CreateBuilder();
		builder.Services.AddControllers()
			.PartManager
			.ApplicationParts
			.Add(new AssemblyPart(Assembly.Load("RndTech.Talks.WebApplicationFactory")));

		builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureContainer<ContainerBuilder>(b => b.RegisterInstance("working"));

		app = builder.Build();
		app.MapControllers();
		app.Start();
	}

	public ValueTask DisposeAsync() => app.DisposeAsync();
}