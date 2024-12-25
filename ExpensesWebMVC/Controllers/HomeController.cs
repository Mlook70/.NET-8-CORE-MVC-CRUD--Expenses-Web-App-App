using System.Diagnostics;
using ExpensesWebMVC.Models;
using Microsoft.AspNetCore.Mvc;

//Abdulmalek Akel

namespace ExpensesWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpensesWebMVCDbContext _context;

        public HomeController(ILogger<HomeController> logger, ExpensesWebMVCDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var totalExpensesValue = allExpenses.Sum(x => x.Value);

            ViewBag.Expenses = totalExpensesValue;
            return View(allExpenses);
        }        
        public IActionResult CreateEditExpenses(int? Id)
        {
            if (Id != null)
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == Id);
                return View(expenseInDb);
            }
            else
            {
                return View();
            }
        }       
        public IActionResult CreateEditExpensesForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model);
            } else {
                _context.Expenses.Update(model);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult DeleteExpenses(int Id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(x => x.Id == Id);
            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
