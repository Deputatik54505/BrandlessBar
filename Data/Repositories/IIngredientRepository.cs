using brandlessBar.Data.Models;

namespace brandlessBar.Data.Repositories;

public interface IIngredientRepository
{
	public Task<Ingredient?> Get(int id);
	public Task<Ingredient?> Get(string name);
	public Task<List<Ingredient>> GetAll();
	public bool Create(Ingredient ingredient);
	public bool Update(Ingredient ingredient);
	public bool Delete(Ingredient ingredient);
}