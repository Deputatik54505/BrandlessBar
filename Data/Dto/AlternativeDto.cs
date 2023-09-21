using brandlessBar.Data.Models;

namespace brandlessBar.Data.Dto
{
	public class AlternativeDto
	{
		public string Name { get; set; }
		public Ingredient? PreferableIngredient { get; set; }
		public List<Ingredient> Ingredients { get; set; } = new();
	}
}
