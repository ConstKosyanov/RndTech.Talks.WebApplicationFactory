using Microsoft.AspNetCore.Mvc;

namespace RndTech.Talks.WebApplicationFactory;

[ApiController]
[Route("")]
public class HomeController : Controller
{
	private readonly string pingResponse;

	public HomeController(string pingResponse) => this.pingResponse = pingResponse;

	[HttpGet("ping")]
	public string Ping() => pingResponse;
}