using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace brandlessBar.Data.Repositories;

public class IngredientRepository : IIngredientRepository
{
	private readonly ApplicationDbContext _context;

	public IngredientRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Ingredient?> Get(int id)
	{
		return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
	}

	public async Task<Ingredient?> Get(string name)
	{
		return await _context.Ingredients.FirstOrDefaultAsync(i => i.Name.Equals(name));
	}

	public async Task<List<Ingredient>> GetAll()
	{
		return await _context.Ingredients.ToListAsync();
	}

	public bool Create(Ingredient ingredient)
	{
		if (_context.Ingredients.Contains(ingredient))
			return false;

		_context.Ingredients.Add(ingredient);
		return Save();
	}

	public bool Update(Ingredient ingredient)
	{
		if (!_context.Ingredients.Contains(ingredient))
			return false;
		_context.Ingredients.Update(ingredient);
		return Save();
	}

	public bool Delete(Ingredient ingredient)
	{
		if(!_context.Ingredients.Contains(ingredient))
			return false;
		_context.Ingredients.Remove(ingredient);
		return Save();
	}

	private bool Save()
	{
		return _context.SaveChanges() > 0;
	}
}