using brandlessBar.Data.Models;

namespace brandlessBar.Data.Repositories;

public interface ICocktailRepository
{
	public Task<Cocktail?> Get(int id);
	public Task<Cocktail?> Get(string name);
	public Task<List<Cocktail>> GetAll();
	public bool Create (Cocktail cocktail);
	public bool Update (Cocktail cocktail);
	public bool Delete (Cocktail cocktail);
}