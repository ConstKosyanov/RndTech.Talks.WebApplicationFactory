using Microsoft.EntityFrameworkCore;

namespace RndTech.Talks.WebApplicationFactory;

public class MyContext : DbContext
{
	public MyContext(DbContextOptions<MyContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<MyRecord>(b =>
		{
			b.HasKey(x => x.Id);
		});
	}

	public DbSet<MyRecord> Records { get; set; }
}

public record MyRecord(Guid Id, string Value);
