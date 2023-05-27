using Microsoft.AspNetCore.Mvc;

namespace RndTech.Talks.WebApplicationFactory;

[ApiController]
[Route("")]
public class HomeController : Controller
{
	private readonly MyContext myContext;

	public HomeController(MyContext myContext) => this.myContext = myContext;

	[HttpGet("ping")]
	public string Ping()
	{
		var entity = myContext.Add(new MyRecord(Guid.NewGuid(), "ping")).Entity;
		myContext.SaveChanges();
		return entity.Value;
	}
}