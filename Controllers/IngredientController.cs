using AutoMapper;
using brandlessBar.Data.Dto;
using brandlessBar.Data.Models;
using brandlessBar.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : Controller
{

	private readonly IRepository<Ingredient> _repository;
	private readonly IMapper _mapper;


	public IngredientController(IRepository<Ingredient> repository, IMapper mapper)
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
	public IActionResult Create([FromBody]IngredientDto ingredient)
	{
		//TODO: make it possible to attach a picture of ingredient
		
		_repository.Create(_mapper.Map<Ingredient>(ingredient));
		return Ok(ingredient);
	}
}
