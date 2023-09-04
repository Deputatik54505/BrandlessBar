using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using brandlessBar.Data;
using Microsoft.Extensions.Options;
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
		var gin = new Ingredient("gin", "Spirit");
		var vodka = new Ingredient("vodka", "Spirit");
		var whiskey = new Ingredient("whiskey", "Spirit");

		alt.Ingredients.Add(gin);
		alt.Ingredients.Add(vodka);
		alt.Ingredients.Add(whiskey);

		
		alt.PreferableIngredient = whiskey;

		Assert.True(repository.Create(alt));
	}

	[Fact]
	public void Update_Alternative()
	{
		Alternative? spirit;
		var context = new ApplicationDbContext();
		var repository = new AlternativeRepository(context);
		Ingredient vodka;

		spirit = context.Alternatives.FirstOrDefault(alt => alt.Name.Equals("Spirit"));
		if (spirit == null) 
			Assert.Fail();
		vodka = spirit.Ingredients.First(ing => ing.Name.Equals("vodka"));
		spirit.PreferableIngredient = vodka;

		Assert.True(repository.Update(spirit));
	}

	[Fact]
	public void Delete_Alternative()
	{
		var context = new ApplicationDbContext();
		var repository = new AlternativeRepository(context);
		Alternative? spirit;

		spirit = context.Alternatives.FirstOrDefault(alt => alt.Name.Equals("Spirit"));
		if (spirit == null) Assert.Fail();
		

		Assert.True(repository.Delete(spirit));

	}

}
