using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace brandlessBar.Data.Repositories;

public class CocktailRepository : ICocktailRepository
{
	private readonly ApplicationDbContext _context;

	public CocktailRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Cocktail?> Get(int id)
	{
		return await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<Cocktail?> Get(string name)
	{
		return await _context.Cocktails.FirstOrDefaultAsync(c => c.Name.Equals(name));
	}

	public async Task<List<Cocktail>> GetAll()
	{
		return await _context.Cocktails.ToListAsync();
	}

	public bool Create(Cocktail cocktail)
	{
		if (_context.Cocktails.FirstOrDefault(c => c.Id == cocktail.Id) == null)
			return false;

		_context.Cocktails.Add(cocktail);
		return Save();
	}

	public bool Update(Cocktail cocktail)
	{
		if (!_context.Cocktails.Contains(cocktail))
			return false;
		_context.Cocktails.Update(cocktail);
		return Save();
	}

	public bool Delete(Cocktail cocktail)
	{
		if(!_context.Cocktails.Contains(cocktail))
			return false;

		_context.Cocktails.Remove(cocktail);
		return Save();
	}

	private bool Save()
	{
		return _context.SaveChanges() > 0;
	}
}