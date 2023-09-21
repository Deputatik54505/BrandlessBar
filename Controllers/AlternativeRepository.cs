using AutoMapper;
using brandlessBar.Data.Dto;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlternativeRepository : Controller
{
	private readonly IRepository<Alternative> _repository;
	private readonly IMapper _mapper;

	public AlternativeRepository(IRepository<Alternative> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpPost]
	[Route("create")]
	public IActionResult Create(AlternativeDto alternative)
	{
		_repository.Create(_mapper.Map<Alternative>(alternative));
		return Ok(alternative);
	}
}
