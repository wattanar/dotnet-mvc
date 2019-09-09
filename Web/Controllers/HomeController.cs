using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Domain;
using Web.Domain.Entities;
using Web.Models;

namespace Web.Controllers
{
  public class HomeController : Controller
  {
    private DataDbContext _dataDbContext;

    public HomeController(DataDbContext dataDbContext)
    {
      _dataDbContext = dataDbContext;
    }

    public JsonResult Index()
    {
      using (var unitOfWork = new UnitOfWork(_dataDbContext))
      {
        return Json(unitOfWork.Users.GetSomeUser(1));
      }
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
