using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

[Controller]
public class RecipesController : Controller
{
	private readonly IRepository<Cocktail> _repository;

	public RecipesController(IRepository<Cocktail> repository)
	{
		_repository = repository;
	}


	public IActionResult Index()
	{
		return View(_repository.GetAll().Result);
	}
}