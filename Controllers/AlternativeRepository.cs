using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlternativeRepository : Controller
{
	private readonly IRepository<Alternative> _repository;

	public AlternativeRepository(IRepository<Alternative> repository)
	{
		_repository = repository;
	}

	[HttpPost]
	[Route("create")]
	public IActionResult Create(Alternative alternative)
	{
		_repository.Create(alternative);
		return Ok(alternative);
	}
}
