using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using brandlessBar.Utils;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RecipesController : Controller
{
	private readonly IRepository<Cocktail> _repository;

	public RecipesController(IRepository<Cocktail> repository)
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
	public IActionResult Create([FromBody] Cocktail cocktail,[FromForm] Image? picture)
	{
		if (picture !=null)
		{
			cocktail.Picture = ImageUtils.ImageToByteArray(picture);
		}

		_repository.Create(cocktail);

		return View();
	}

}