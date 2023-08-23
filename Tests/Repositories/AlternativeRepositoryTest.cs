using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using brandlessBar.Data;
using Xunit;

namespace brandlessBar.Tests.Repositories;

public class AlternativeRepositoryTest
{
	[Fact]
	public void Create_New_Alternative()
	{
		var alt = new Alternative("Spirit");
		var context = new ApplicationDbContext();
		var repository = new AlternativeRepository(context);
		var gin = new Ingredient("Gin", "Spirit");
		var vodka = new Ingredient("Vodka", "Spirit");
		var whiskey = new Ingredient("whiskey", "Spirit");

		alt.Ingredients.Add(gin);
		alt.Ingredients.Add(vodka);
		alt.Ingredients.Add(whiskey);

		alt.PreferableIngredient = whiskey;

		Assert.True(repository.Create(alt));
	}

}