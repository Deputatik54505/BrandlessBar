using brandlessBar.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace brandlessBar.Controllers
{
	public interface ICocktailController
	{
		public IActionResult Get(int id);
		public IActionResult Post(Cocktail cocktail);
		public IActionResult Put(Cocktail cocktail);
		public IActionResult Delete(int id);
	}
}
