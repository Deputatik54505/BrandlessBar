using brandlessBar.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace brandlessBar.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Alternative> Alternatives => Set<Alternative>();
		public DbSet<Cocktail> Cocktails => Set<Cocktail>();
		public DbSet<Ingredient> Ingredients => Set<Ingredient>();
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("User Id=postgres;Password=b1cJBQZ0e6BjaI06;Server=db.njuuzelhimoeiztijwvd.supabase.co;Port=5432;Database=postgres");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Alternative>(a =>
			{
				a.HasKey(alt => alt.Id);

				a.HasMany(alt => alt.Ingredients)
					.WithMany();

				a.HasOne(alt => alt.PreferableIngredient).WithMany();
			});

			builder.Entity<Cocktail>(c =>
			{
				c.HasKey(cock => cock.Id);

				c.Property(cock => cock.Name).IsRequired();

				c.Property(cock => cock.Description);

				c.HasMany(cock => cock.Alternatives).WithMany();

				c.HasMany(cock => cock.OptionalAlternatives).WithMany();
			});

			builder.Entity<Ingredient>(i =>
			{
				i.HasKey(ing => ing.Id);

				i.Property(ing => ing.Name).IsRequired();

				i.Property(ing => ing.Description);

				i.Property(ing => ing.Type).IsRequired();
			});

			base.OnModelCreating(builder);
		}
	}
}