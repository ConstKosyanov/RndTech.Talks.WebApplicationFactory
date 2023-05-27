namespace RndTech.Talks.WebApplicationFactory.Tests;

public class UnitTest
{
	[Fact]
	public async Task PingTest()
	{
		var httpClient = new HttpClient();
		Assert.Equal("working", await httpClient.GetStringAsync("http://localhost:5000/ping"));
	}
}