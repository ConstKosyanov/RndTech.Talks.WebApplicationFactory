using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace RndTech.Talks.WebApplicationFactory;

public class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddControllers();
		builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureContainer<ContainerBuilder>(b => b.RegisterInstance("working"));

		var app = builder.Build();
		app.MapControllers();
		app.Run();
	}
}