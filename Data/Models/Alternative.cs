using Microsoft.VisualBasic.CompilerServices;

namespace brandlessBar.Data.Models;

public class Alternative : ISuperModel
{
	public Alternative(string name)
	{
		Name = name;
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public Ingredient? PreferableIngredient { get; set; }
	public List<Ingredient> Ingredients { get; set; } = new();
}