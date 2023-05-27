using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RndTech.Talks.WebApplicationFactory;

public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddControllers();
		builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureServices(ConfigureServices)
			.ConfigureContainer<ContainerBuilder>(b => b.RegisterInstance("working"));

		var app = builder.Build();
		app.MapControllers();
		app.Run();

		static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
		{
			services.AddDbContext<MyContext>(x => x.UseSqlServer(context.Configuration.GetConnectionString("my")));
		}
	}
}