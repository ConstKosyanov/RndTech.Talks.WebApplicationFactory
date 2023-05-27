using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace RndTech.Talks.WebApplicationFactory.Tests;

public class UnitTest : IClassFixture<MyWebApplicationFactory>
{
	private readonly MyWebApplicationFactory webApplicationFactory;

	public UnitTest(MyWebApplicationFactory webApplicationFactory)
	{
		this.webApplicationFactory = webApplicationFactory;
	}

	[Fact]
	public async Task PingTest()
	{
		var httpClient = webApplicationFactory.CreateClient();
		Assert.Equal("ping", await httpClient.GetStringAsync("ping"));

		var options = new DbContextOptionsBuilder<MyContext>()
			.UseInMemoryDatabase("MyDatabase")
			.Options;

		using var ctx = new MyContext(options);
		Assert.Equal("ping", ctx.Records.Single().Value);
	}
}

public class MyWebApplicationFactory : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureServices(s =>
		{
			s.RemoveAll<DbContextOptions<MyContext>>();
			s.AddDbContext<MyContext>(x => x.UseInMemoryDatabase("MyDatabase"));
		});
	}
}