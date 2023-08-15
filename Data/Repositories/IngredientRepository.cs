using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NLog;

namespace brandlessBar.Data.Repositories;

public class IngredientRepository : IIngredientRepository
{
	private readonly ApplicationDbContext _context;
	private readonly Logger _logger = NLog.LogManager.GetCurrentClassLogger();

	public IngredientRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Ingredient?> Get(int id)
	{
		_logger.Trace($"attempt to GET Ingredient by id {id}");
		return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
	}

	public async Task<Ingredient?> Get(string name)
	{
		_logger.Trace($"attempt to GET Ingredient by name {name}");
		return await _context.Ingredients.FirstOrDefaultAsync(i => i.Name.Equals(name));
	}

	public async Task<List<Ingredient>> GetAll()
	{
		_logger.Trace($"attempt to GETALL ingredients");
		return await _context.Ingredients.ToListAsync();
	}

	public bool Create(Ingredient ingredient)
	{
		_logger.Trace($"attempt to CREATE Ingredient {ingredient}");

		if (_context.Ingredients.Contains(ingredient))
		{
			_logger.Warn($"ingredient {ingredient} already in context ");
			return false;
		}
		
		_context.Ingredients.Add(ingredient);
		
		return Save();
	}

	public bool Update(Ingredient ingredient)
	{
		_logger.Trace($"attempt to UPDATE Ingredient {ingredient}");
		if (_context.Ingredients.FirstOrDefault(i=>i.Id==ingredient.Id) == null)
		{
			_logger.Warn($"No ingredient with id {ingredient.Id} in context");
			return false;
		}
		_context.Ingredients.Update(ingredient);
		return Save();
	}

	public bool Delete(Ingredient ingredient)
	{
		_logger.Trace($"attempt to DELETE Ingredient {ingredient}");
		if (!_context.Ingredients.Contains(ingredient))
		{
			_logger.Warn("No such ingredient in context");
			return false;
		}
		_context.Ingredients.Remove(ingredient);
		return Save();
	}

	private bool Save()
	{
		if (_context.SaveChanges() > 0)
		{
			_logger.Trace("Changes saved");
			return true;
		}
		_logger.Warn("changes weren't saved");
		return false;
	}
}