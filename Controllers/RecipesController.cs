using System.Reflection.Metadata.Ecma335;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using brandlessBar.Utils;
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


	[HttpGet]
	public IActionResult Index()
	{
		return View(_repository.GetAll().Result);
	}


	[HttpPost]
	[ProducesResponseType(204)]
	public IActionResult Create([FromBody] Cocktail cocktail, Image? picture)
	{
		if (picture != null)
			cocktail.Picture = ImageUtils.ImageToByteArray(picture);

		_repository.Create(cocktail);
		return Ok();
	}

}