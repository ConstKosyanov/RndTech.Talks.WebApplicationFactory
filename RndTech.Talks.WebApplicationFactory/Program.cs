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
			.ConfigureContainer<ContainerBuilder>(ConfigureContainer);

		var app = builder.Build();
		app.MapControllers();
		app.Run();
	}

	private static void ConfigureContainer(HostBuilderContext context, ContainerBuilder builder)
	{
		var pingResponse = context.Configuration.GetValue<string>("ping_response")
			?? throw new NullReferenceException("ping_response is null");
		builder.RegisterInstance(pingResponse);
	}
}