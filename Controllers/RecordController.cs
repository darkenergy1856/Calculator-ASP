using Calculator.Data;
using Calculator.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Controllers
{
	public class RecordController : Controller
	{
		private readonly ApplicationDbContext dbContext;

		public RecordController(ApplicationDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var record = await dbContext.Calculations.ToListAsync();
			return View(record);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var record = await dbContext.Calculations.FindAsync(id);
			if (record is not null)
			{
				dbContext.Calculations.Remove(record);
				await dbContext.SaveChangesAsync();
			}
			return RedirectToAction("Index" , "Record");
		}
	}
}
