using brandlessBar.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers;

public interface IIngredientController
{
	public IActionResult Get(int id);
	public IActionResult Post(Ingredient ingredient);
	public IActionResult Put(Ingredient ingredient);
	public IActionResult Delete(int id);

}