using brandlessBar.Data;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace brandlessBar.Tests.Repositories;

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
}