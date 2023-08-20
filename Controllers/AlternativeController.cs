using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace brandlessBar.Controllers;

public class AlternativeController : Controller, IAlternativeController
{
	private readonly IAlternativeRepository _repository;
	private readonly Logger _logger = LogManager.GetCurrentClassLogger();

	public AlternativeController(IAlternativeRepository repository)
	{
		_repository = repository;
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(404)]
	public IActionResult Get([FromBody] int id)
	{
		_logger.Trace($"attempt to get alternative with id {id}");
		var alternative = _repository.Get(id).Result;
		if (alternative == null)
		{
			_logger.Debug("alternative wasn't found");
			return NotFound();
		}
		_logger.Trace($"returns alternative {alternative}");
		return Ok(alternative);
	}

	[HttpPost]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Post([FromBody] Alternative alternative)
	{
		_logger.Trace($"attempt to add alternative {alternative} in repository");
		if (_repository.Create(alternative))
		{
			_logger.Trace("alternative added to db");
			return StatusCode(204);
		}
		_logger.Warn("alternative wasn't added to the db");
		return BadRequest();
	}

	[HttpPut]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public IActionResult Put([FromBody] Alternative alternative)
	{
		_logger.Trace($"attempt to update alternative with id {alternative.Id} ");
		if (_repository.Update(alternative))
		{
			_logger.Debug($"alternative {alternative.Id} was successfuly updated");
			return StatusCode(204);
		}
		_logger.Warn($"alternative {alternative} wasn't updated");
		return BadRequest();
	}

	public IActionResult Delete([FromBody] int id)
	{
		_logger.Trace($"attempt to delete alternative {id}");
		var alternative = _repository.Get(id).Result;
		if (alternative == null)
		{
			_logger.Debug("alternative weren't found");
			return NotFound();
		}

		if (_repository.Delete(alternative))
		{
			_logger.Trace($"alternative {alternative} deleted");
			return Ok(alternative);
		}
		_logger.Warn($"alternative {alternative} wasn't deleted");
		return BadRequest();
	}
}