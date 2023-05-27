using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace RndTech.Talks.WebApplicationFactory.Tests;

public class UnitTest : IClassFixture<CompositeWebApplicationFactory>
{
	private readonly CompositeWebApplicationFactory composite;

	public UnitTest(CompositeWebApplicationFactory composite) => this.composite = composite;

	[Fact]
	public async Task PingTest() => Assert.All(await composite.GetStringAsync("ping"), x => Assert.Equal("working", x));
}

public class CompositeWebApplicationFactory : IAsyncDisposable
{
	public WebApplicationFactory<Program> WebApplicationFactory1 { get; } = new WebApplicationFactory<Program>();
	public WebApplicationFactory<Program> WebApplicationFactory2 { get; } = new WebApplicationFactory<Program>();

	public async Task<IEnumerable<string>> GetStringAsync(string requestUrl)
	{
		return await Task.WhenAll(new[]
		{
			WebApplicationFactory1.CreateClient().GetStringAsync(requestUrl),
			WebApplicationFactory2.CreateClient().GetStringAsync(requestUrl)
		});
	}

	public async ValueTask DisposeAsync()
	{
		await WebApplicationFactory1.DisposeAsync();
		await WebApplicationFactory2.DisposeAsync();
	}
}