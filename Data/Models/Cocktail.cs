namespace brandlessBar.Data.Models;

public class Cocktail : SuperModel
{
	public Cocktail(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public byte[] Picture { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
	public List<Alternative>? Alternatives { get; set; }
	public List<Alternative>? OptionalAlternatives { get; set; }
}