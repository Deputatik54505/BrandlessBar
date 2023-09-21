using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController <T> : Controller where T : class, ISearchable
	{
		private readonly SearchableRepository<T> _repository;

		public SearchController(SearchableRepository<T> repository)
		{
			_repository = repository;
		}


		public IActionResult Search(string searchString)
		{
			List<T> firstPriority = new List<T>();
			List<T> secondPriority = new List<T>();
			

			return null;
		}
	}
}
