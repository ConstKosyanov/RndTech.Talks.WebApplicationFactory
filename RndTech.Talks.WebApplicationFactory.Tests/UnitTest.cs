using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RndTech.Talks.WebApplicationFactory.Tests;

public class UnitTest : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly WebApplicationFactory<Program> webApplicationFactory;

	public UnitTest(WebApplicationFactory<Program> webApplicationFactory)
	{
		this.webApplicationFactory = webApplicationFactory;
	}

	[Fact]
	public async Task PingTest()
	{
		var httpClient = webApplicationFactory.CreateClient();
		Assert.Equal("working", await httpClient.GetStringAsync("ping"));
	}
}