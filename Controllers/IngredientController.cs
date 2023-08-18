using brandlessBar.Data;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using NLog;
using ILogger = NLog.ILogger;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : Controller, IIngredientController
{

	private readonly IIngredientRepository _repository;
	private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

	public IngredientController(IIngredientRepository repository)
	{
		_repository = repository;
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	public IActionResult Get(int id)
	{
		var ingredient = _repository.Get(id).Result;
		if (ingredient == null)
		{
			return NotFound();
		}
		return Ok(ingredient);
	}


	[HttpPost]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Post(Ingredient ingredient)
	{
		if (_repository.Create(ingredient))
		{
			return StatusCode(204);
		}
		return BadRequest();
	}

	[HttpPut]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Update(Ingredient ingredient)
	{
		if (_repository.Update(ingredient))
		{
			return StatusCode(204);
		}
		return BadRequest();
	}

	[HttpDelete]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	[ProducesResponseType(400)]
	public IActionResult Delete(int id)
	{
		var ingredient = _repository.Get(id).Result;
		if (ingredient == null)
			return NotFound();
		if (_repository.Delete(ingredient))
		{
			return Ok(ingredient);
		}
		return BadRequest();
	}
}