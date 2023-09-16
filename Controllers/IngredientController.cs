using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : Controller
{

	private readonly IRepository<Ingredient> _repository;

	public IngredientController(IRepository<Ingredient> repository)
	{
		_repository = repository;
	}


	[HttpGet]
	[Route("getAll")]
	public IActionResult GetAll()
	{
		return Ok(_repository.GetAll().Result);
	}

	[HttpPost]
	[Route("create")]
	public IActionResult Create([FromBody]Ingredient ingredient, [FromForm]Image? picture)
	{

		_repository.Create(ingredient);
		return View();
	}
}
