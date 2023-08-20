using brandlessBar.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

public interface IAlternativeController
{
	public IActionResult Get(int id);
	public IActionResult Post(Alternative cocktail);
	public IActionResult Put(Alternative cocktail);
	public IActionResult Delete(int id);
}