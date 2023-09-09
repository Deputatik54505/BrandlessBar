using brandlessBar.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace brandlessBar.Data.Repositories;

public class Repository<T> : IRepository<T> where T : SuperModel
{
	private readonly ApplicationDbContext _context;
	private readonly DbSet<T> _entities;

	public Repository(ApplicationDbContext context)
	{
		_context = context;
		_entities = context.Set<T>();
	}

	public Task<T?> Get(int id)
	{
		return _entities.SingleOrDefaultAsync(e => e.Id == id);
	}

	public Task<List<T>> GetAll()
	{
		return _entities.AsQueryable().ToListAsync();
	}

	public bool Create(T entity)
	{
		_entities.Add(entity);
		return _context.SaveChanges() > 0;
	}

	public bool Update(T entity)
	{
		_entities.Update(entity);
		return _context.SaveChanges() > 0;
	}

	public bool Delete(T entity)
	{
		_entities.Remove(entity);
		return _context.SaveChanges() > 0;
	}
}