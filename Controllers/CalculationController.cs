using Calculator.Models.Entities;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Calculator.Data;

namespace Calculator.Controllers
{
	public class CalculationController : Controller
	{

		private ApplicationDbContext DbContext { get; }

		public CalculationController(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}

		[HttpPost, HttpGet]
		public async Task<IActionResult> Index(AddCalculationViewModel viewModel)
		{
			if (viewModel.expression != null)
			{
				int count = 0;
				string[] expressionArray = new string[3];
				var result = 0.0;
				string tempExpression = viewModel.expression.Trim();
				int currentExpression = 0;
				string currentOperator = "";
				if (tempExpression.Contains("+"))
				{
					currentExpression = 1;
					currentOperator = "+";
					expressionArray = tempExpression.Split('+');
					count++;
				}
				if (tempExpression.Contains("-"))
				{
					currentExpression = 2;
					currentOperator = "-";
					expressionArray = tempExpression.Split('-');
					count++;
				}
				if (tempExpression.Contains("*"))
				{
					currentExpression = 3;
					currentOperator = "*";
					expressionArray = tempExpression.Split('*');
					count++;
				}
				if (tempExpression.Contains("/"))
				{
					currentExpression = 4;
					currentOperator = "/";
					expressionArray = tempExpression.Split('/');
					count++;
				}

				if (count == 1)
				{
					try
					{
						switch (currentExpression)
						{
							case 1:
								result = Convert.ToInt32(expressionArray[0]) + Convert.ToInt32(expressionArray[1]);
								break;
							case 2:
								result = Convert.ToInt32(expressionArray[0]) - Convert.ToInt32(expressionArray[1]);
								break;
							case 3:
								result = Convert.ToInt32(expressionArray[0]) * Convert.ToInt32(expressionArray[1]);
								break;
							case 4:
								result = Convert.ToInt32(expressionArray[0]) / Convert.ToInt32(expressionArray[1]);
								break;
							default:
								Console.WriteLine("\nUnknown Operand");
								break;

						}

						var temporary = new Calculation { operand1 = expressionArray[0].Trim(), operand2 = expressionArray[1].Trim(), opeator = currentOperator, result = result.ToString() };
						await DbContext.Calculations.AddAsync(temporary);
						await DbContext.SaveChangesAsync();
						viewModel.expression = "";
						Console.WriteLine(temporary.result.ToString());
					}
					catch (Exception e)
					{
						Console.WriteLine(e.ToString());
					}

				}
			}
			return View();
		}
	}
}
