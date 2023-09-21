using brandlessBar.Data.Models;

namespace brandlessBar.Data.Repositories
{
	public class SearchableRepository<T> : Repository<T> where T : class, ISearchable
	{
		public SearchableRepository(ApplicationDbContext context) : base(context)
		{
		}


		public T Get(string name)
		{
			return _entities.First(e => e.Name == name);
		}

		public List<T> inName(string word)
		{
			return _entities.Where(e => e.Name.Contains(word)).ToList();
		}
		public List<T> InDescription(string word) {
			return _entities.Where(e => e.Description!=null && e.Description.Contains(word)).ToList();
		}
	}
}
