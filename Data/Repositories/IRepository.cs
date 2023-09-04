using brandlessBar.Data.Models;

namespace brandlessBar.Data.Repositories;

public interface IRepository<T> where T : SuperModel
{
	public Task<T?> Get(int id);
	public Task<List<T>> GetAll();

	public bool Create(T entity);
	public bool Update(T entity);
	public bool Delete(T entity);

}