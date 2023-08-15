using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace brandlessBar.Data.Repositories;

public class CocktailRepository : ICocktailRepository
{
	private readonly ApplicationDbContext _context;
	private readonly Logger _logger = LogManager.GetCurrentClassLogger();
	public CocktailRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Cocktail?> Get(int id)
	{
		_logger.Trace($"attempt to GET Cocktail by id {id}");
		return await _context.Cocktails.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<Cocktail?> Get(string name)
	{
		_logger.Trace($"attempt to GET Cocktail by name {name}");
		return await _context.Cocktails.FirstOrDefaultAsync(c => c.Name.Equals(name));
	}

	public async Task<List<Cocktail>> GetAll()
	{
		_logger.Trace($"attempt to GETALL Cocktails");
		return await _context.Cocktails.ToListAsync();
	}

	public bool Create(Cocktail cocktail)
	{
		_logger.Trace($"attempt to CREATE Cocktail {cocktail}");

		if (_context.Cocktails.Contains(cocktail))
		{
			_logger.Warn($"cocktail with id {cocktail.Id} already in context");
			return false;
		}

		_context.Cocktails.Add(cocktail);
		return Save();
	}

	public bool Update(Cocktail cocktail)
	{
		_logger.Trace($"attempt to CREATE Cocktail {cocktail}");

		if (_context.Cocktails.FirstOrDefault(c => c.Id == cocktail.Id) == null)
		{
			_logger.Warn($"No cocktail with id {cocktail.Id} in context");
			return false;
		}
		_context.Cocktails.Update(cocktail);
		return Save();
	}

	public bool Delete(Cocktail cocktail)
	{
		_logger.Trace($"attempt to Delete Cocktail {cocktail}");


		if (!_context.Cocktails.Contains(cocktail))
		{
			_logger.Warn($"No cocktail with id {cocktail.Id} in context");
			return false;
		}

		_context.Cocktails.Remove(cocktail);
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