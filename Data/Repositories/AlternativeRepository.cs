using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace brandlessBar.Data.Repositories;

public class AlternativeRepository : IAlternativeRepository
{
	private readonly ApplicationDbContext _context;
	private readonly Logger _logger = LogManager.GetCurrentClassLogger();

	public AlternativeRepository(ApplicationDbContext context)
	{
		_context = context;
		_logger.Debug("repository initialized");
	}

	public async Task<Alternative?> Get(int id)
	{
		_logger.Trace($"attempt to GET Alternative by id {id}");
		return await _context.Alternatives.FirstOrDefaultAsync(a => a.Id == id);
	}


	public async Task<Alternative?> Get(Ingredient preferableIngredient)
	{
		_logger.Trace($"attempt to GET Alternative by preferable ingredient {preferableIngredient}");

		return await _context.Alternatives.FirstOrDefaultAsync(
			a => a.PreferableIngredient != null
				 && a.PreferableIngredient.Equals(preferableIngredient));
	}

	public async Task<List<Alternative>> GetAll()
	{
		_logger.Trace($"attempt to GETALL Alternatives");

		return await _context.Alternatives.ToListAsync();
	}

	public bool Delete(Alternative alternative)
	{
		_logger.Trace($"attempt to DELETE Alternative with id {alternative.Id}");

		if (!_context.Alternatives.Contains(alternative))
		{
			_logger.Warn($"No alternatives with id {alternative.Id}");
			return false;
		}
		_context.Alternatives.Remove(alternative);
		return Save();
	}

	public bool Update(Alternative alternative)
	{
		_logger.Trace($"attempt to UPDATE Alternative {alternative}");

		if (_context.Alternatives.FirstOrDefault(a=>a.Id==alternative.Id) == null)
		{
			_logger.Warn($"No alternatives with id {alternative.Id}");
			return false;
		}
		_context.Alternatives.Update(alternative);
		return Save();
	}

	public bool Create(Alternative alternative)
	{
		_logger.Trace($"attempt to CREATE Alternative {alternative}");

		if (_context.Alternatives.FirstOrDefault(a => a.Id == alternative.Id) != null)
		{
			_logger.Warn($"Alternative with id {alternative.Id} already in db");
			return false;
		}

		_context.Alternatives.Add(alternative);
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
