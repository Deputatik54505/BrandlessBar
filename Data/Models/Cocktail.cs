namespace brandlessBar.Data.Models;

public class Cocktail : ISuperModel, ISearchable
{
	public Cocktail(string name)
	{
		Name = name;
	}
	public int Id { get; set; }

	public byte[] Picture { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
	public List<Alternative>? Alternatives { get; set; }
	public List<Alternative>? OptionalAlternatives { get; set; }
}