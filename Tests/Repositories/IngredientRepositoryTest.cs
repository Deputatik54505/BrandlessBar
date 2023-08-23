using brandlessBar.Data;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace brandlessBar.Tests.Repositories;

/// <summary>
/// The test class for Ingredient repository
/// Expected to run all together
/// </summary>
public class IngredientRepositoryTest
{
	[Fact]
	public void Create_new_Ingredient()
	{
		var ingredient = new Ingredient("apple","fruit");
		var context = new ApplicationDbContext();
		var repository = new IngredientRepository(context);
		ingredient.Description = "Fresh apple, may be used as garnish";


		var result = repository.Create(ingredient);
			
		Assert.True(result);
	}

	[Fact]
	public void Get_Apple()
	{
		var context = new ApplicationDbContext();
		var repository = new IngredientRepository(context);
		Ingredient? apple;
		int appleId;


		apple = context.Ingredients.FirstOrDefault(i => i.Name.Equals("apple"));
		if (apple==null)
			Assert.Fail();
		appleId = apple.Id;
		apple = repository.Get(appleId).Result;

		if (apple == null)
			Assert.Fail();
		Assert.Equivalent(apple.Name,"apple");
	}

	[Fact]
	public void Update_Ingredient()
	{
		var context = new ApplicationDbContext();
		var repository = new IngredientRepository(context);
		Ingredient? apple;

		apple = context.Ingredients.FirstOrDefault(i => i.Name.Equals("apple"));
		if (apple == null ) Assert.Fail();
		apple.Description = "not as fresh apple";


		Assert.True(repository.Update(apple));
	}

	[Fact]
	public void Delete_Ingredient()
	{
		var context = new ApplicationDbContext();
		var repository = new IngredientRepository(context);
		Ingredient? apple;

		apple = context.Ingredients.FirstOrDefault(i => i.Name.Equals("apple"));
		if (apple==null)
			Assert.Fail();

		Assert.True(repository.Delete(apple));

	}
}