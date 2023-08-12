using Microsoft.VisualBasic.CompilerServices;

namespace brandlessBar.Data.Models;

public class Alternative
{
	public int Id { get; set; }
	public Ingredient? PreferableIngredient { get; set; }
	public List<Ingredient>? Ingredients { get; set; } = new();
}