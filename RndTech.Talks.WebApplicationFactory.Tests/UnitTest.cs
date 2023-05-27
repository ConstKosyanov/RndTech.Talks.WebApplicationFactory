using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
		Assert.Equal("inherited", await httpClient.GetStringAsync("ping"));
	}
}

public class MyWebApplicationFactory : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestContainer<ContainerBuilder>(b => b.RegisterInstance("not working"));
	}

	protected override IHost CreateHost(IHostBuilder builder)
	{
		builder.ConfigureContainer<ContainerBuilder>(b => b.RegisterInstance("inherited"));
		return base.CreateHost(builder);
	}
}