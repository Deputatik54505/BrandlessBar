using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace brandlessBar.Data.Repositories;

public class AlternativeRepository : IAlternativeRepository
{
	private readonly ApplicationDbContext _context;

	public AlternativeRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Alternative?> Get(int id)
	{
		return await _context.Alternatives.FirstOrDefaultAsync(a => a != null
																	&& a.Id == id);
	}

	public async Task<Alternative?> Get(string preferableIngredient)
	{
		return await _context.Alternatives.FirstOrDefaultAsync(
			a => a != null &&
				 a.PreferableIngredient != null &&
				 a.PreferableIngredient.Name.Equals(preferableIngredient));
	}

	public async Task<Alternative?> Get(Ingredient preferableIngredient)
	{
		return await _context.Alternatives.FirstOrDefaultAsync(
			a => a != null
				 && a.PreferableIngredient != null
				 && a.PreferableIngredient.Equals(preferableIngredient));
	}

	public async Task<List<Alternative>> GetAll()
	{
		return await _context.Alternatives.ToListAsync();
	}

	public bool Delete(Alternative alternative)
	{
		if (!_context.Alternatives.Contains(alternative)) return false;
		_context.Alternatives.Remove(alternative);
		return Save();
	}

	public bool Update(Alternative alternative)
	{
		if (!_context.Alternatives.Contains(alternative))
			return false;
		_context.Alternatives.Update(alternative);
		return Save();
	}

	public bool Create(Alternative alternative)
	{
		if (_context.Alternatives.FirstOrDefault(a => a != null
													  && a.Id == alternative.Id) != null)
			return false;

		_context.Alternatives.Add(alternative);
		return Save();
	}

	private bool Save()
	{
		return _context.SaveChanges() > 0;
	}

}