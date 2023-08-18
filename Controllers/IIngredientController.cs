using brandlessBar.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace brandlessBar.Controllers;

public interface IIngredientController
{
	public IActionResult Get(int id);
	public IActionResult Post(Ingredient ingredient);
	public IActionResult Update(Ingredient ingredient);
	public IActionResult Delete(int id);

}