namespace brandlessBar.Data.Models;

public class Ingredient : SuperModel
{
	public Ingredient(string name, string type)
	{
		Name = name;
		Type = type;
	}

	public string Name { get; set; }
	public string? Description { get; set; }
	public string Type { get; set; }
	
}