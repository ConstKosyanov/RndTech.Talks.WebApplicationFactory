using Microsoft.AspNetCore.Mvc;

namespace RndTech.Talks.WebApplicatoinFactory;

[ApiController]
[Route("")]
public class HomeController : Controller
{
	[HttpGet("ping")]
	public string Ping() => "working";
}