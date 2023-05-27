using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

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
		Assert.Equal("overriden", await httpClient.GetStringAsync("ping"));
	}
}

public class MyWebApplicationFactory : WebApplicationFactory<Program>
{
	private static readonly IReadOnlyDictionary<string, string?> configuration = new Dictionary<string, string?>() { ["ping_response"] = "overriden" };

	protected override void ConfigureWebHost(IWebHostBuilder builder) => builder.ConfigureAppConfiguration(c => c.AddInMemoryCollection(configuration));
}