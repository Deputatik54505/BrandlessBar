using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController <T> : Controller where T : ISearchable
	{
		private readonly IRepository<T> _repository;

		public SearchController(IRepository<T> repository)
		{
			_repository = repository;
		}


		public IActionResult Search(string searchString)
		{
			return null;
		}
	}
}
