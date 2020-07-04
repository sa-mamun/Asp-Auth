using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SamTech.ExpenseTrack.Framework;
using SamTech.ExpenseTrack.Membership.Services;
using SamTech.ExpenseTrack.Web.Models;

namespace SamTech.ExpenseTrack.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager _roleManager;
        private readonly SignInManager _signInManager;
        private readonly UserManager _userManager;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, RoleManager roleManager, SignInManager signInManager,
                              UserManager userManager, IEmailSender emailSender)
        {
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var model = new GetExpenseModel();
            return View(model);
        }

        public IActionResult AddExpense()
        {
            var model = new AddExpenseModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExpense(
            [Bind(nameof(AddExpenseModel.Name),
                  nameof(AddExpenseModel.Category),
                  nameof(AddExpenseModel.Amount),
                  nameof(AddExpenseModel.Date))] AddExpenseModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.AddExpense();
                    model.Response = new ResponseModel("Expense Added Successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch(DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch(Exception ex)
                {
                    model.Response = new ResponseModel("Failed To Add Expense", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult EditExpense(int id)
        {
            var model = new EditExpenseModel();
            model.LoadData(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExpense(
            [Bind(nameof(EditExpenseModel.Id),
                  nameof(EditExpenseModel.Name),
                  nameof(EditExpenseModel.Category),
                  nameof(EditExpenseModel.Amount),
                  nameof(EditExpenseModel.Date))] EditExpenseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.EditExpense();
                    model.Response = new ResponseModel("Expense Added Successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Failed To Add Expense", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult DeleteExpense(int id)
        {
            var model = new GetExpenseModel();
            try
            {
                var name = model.DeleteExpense(id);
                model.Response = new ResponseModel($"Expense Item '{name}' Successfully Deleted", ResponseType.Success);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.Response = new ResponseModel("Failed To Delete Expense Item", ResponseType.Failure);
            }
            return View(model);
        }

        public IActionResult GetExpense()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<GetExpenseModel>();
            var data = model.GetExpense(tableModel);
            return Json(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new Membership.Entities.Role("administrator"));
            await _roleManager.CreateAsync(new Membership.Entities.Role("superuser"));
            return View();
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
