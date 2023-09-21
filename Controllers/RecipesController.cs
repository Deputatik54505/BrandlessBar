using AutoMapper;
using brandlessBar.Data.Dto;
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
	private readonly IMapper _mapper;

	public RecipesController(IRepository<Cocktail> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}



	[HttpGet]
	[Route("getAll")]
	public IActionResult GetAll()
	{
		return Ok(_repository.GetAll().Result);
	}

	[HttpPost]
	[Route("create")]
	public IActionResult Create([FromBody] CocktailDto cocktail)
	{
		//todo: allow add pictures.

		_repository.Create(_mapper.Map<Cocktail>(cocktail));

		return View();
	}

}