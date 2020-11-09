using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepDiveWeekAPIManagement.Controllers
{
	public class TodoController : Controller
	{

		public static Dictionary<string, List<string>> Items = new Dictionary<string, List<string>>();

		private string GetUser()
		{
			var userId = Request.Headers.ContainsKey("user-email") ? Request.Headers["user-email"][0] : null;
			return userId;
		}

		// GET: Todo
		public ActionResult Index()
		{
			var user = GetUser();
			return Ok(Items.ContainsKey(user) ? Items[user] : new List<string>());
		}

		// POST: Todo/Create/id
		[HttpPost]
		public ActionResult Create(string id)
		{
			var user = GetUser();
			if (!Items.ContainsKey(user))
			{
				Items.Add(user, new List<string>());
			}
			Items[user].Add(id);
			return Ok();
		}

		// GET: Todo/Delete/id
		[HttpDelete]
		public ActionResult Delete(string id)
		{
			var user = GetUser();
			if (!Items.ContainsKey(user))
			{
				Items.Add(user, new List<string>());
			}
			Items[user].Remove(id);
			return Ok();
		}

	}
}