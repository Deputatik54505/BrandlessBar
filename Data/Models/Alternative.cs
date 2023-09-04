using Microsoft.VisualBasic.CompilerServices;

namespace brandlessBar.Data.Models;

public class Alternative : SuperModel
{
	public Alternative(string name)
	{
		Name = name;
	}

	public string Name { get; set; }
	public Ingredient? PreferableIngredient { get; set; }
	public List<Ingredient> Ingredients { get; set; } = new();
}