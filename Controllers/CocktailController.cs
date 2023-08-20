using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using ILogger = NLog.ILogger;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CocktailController : Controller, ICocktailController
{
	private readonly ICocktailRepository _repository;
	private readonly ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

	public CocktailController(ICocktailRepository cocktailRepository)
	{
		_repository = cocktailRepository;
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	public IActionResult Get([FromBody]int id)
	{
		_logger.Trace($"attempt to get cocktail with id {id}");
		var cocktail = _repository.Get(id).Result;
		if (cocktail == null)
		{
			_logger.Debug("Cocktail wasn't found");
			return NotFound();
		}
		_logger.Trace($"returns cocktail {cocktail}");
		return Ok(cocktail);
	}


	[HttpPost]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Post([FromBody]Cocktail cocktail)
	{
		_logger.Trace($"attempt to add cocktail {cocktail} in repository");
		if (_repository.Create(cocktail))
		{
			_logger.Trace("cocktail added to db");
			return StatusCode(204);
		}
		_logger.Warn("Cocktail wasn't added to the db");
		return BadRequest();
	}

	[HttpPut]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Put([FromBody]Cocktail cocktail)
	{
		_logger.Trace($"attempt to update cocktail with id {cocktail.Id} ");
		if (_repository.Update(cocktail))
		{
			_logger.Debug($"cocltail {cocktail.Id} was successfuly updated");
			return StatusCode(204);
		}
		_logger.Warn($"cocktail {cocktail} wasn't updated");
		return BadRequest();
	}

	[HttpDelete]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	[ProducesResponseType(404)]
	public IActionResult Delete([FromBody]int id)
	{
		_logger.Trace($"attempt to delete cocktail {id}");
		var cocktail = _repository.Get(id).Result;
		if (cocktail == null)
		{
			_logger.Debug("cocktail weren't found");
			return NotFound();
		}

		if (_repository.Delete(cocktail))
		{
			_logger.Trace($"cocktail {cocktail} deleted");
			return Ok(cocktail);
		}
		_logger.Warn($"Cocktail {cocktail} wasn't deleted");
		return BadRequest();
	}
}