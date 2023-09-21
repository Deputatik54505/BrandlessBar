namespace brandlessBar.Data.Models
{
	public interface ISearchable : ISuperModel
	{
		string Name { get; set; }
		string? Description { get; set; }
	}
}
