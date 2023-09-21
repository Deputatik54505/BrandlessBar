using brandlessBar.Data.Models;

namespace brandlessBar.Data.Dto
{
	public class CocktailDto
	{
		public string Name { get; set; }
		public string? Description { get; set; }

		public List<Alternative>? Alternatives { get; set; }
		public List<Alternative>? OptionalAlternatives { get; set; }
	}
}
