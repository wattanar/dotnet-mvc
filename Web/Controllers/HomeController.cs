using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Domain;
using Web.Domain.Entities;
using Web.Models;
using Web.Services.Interfaces;

namespace Web.Controllers
{
  public class HomeController : Controller
  {
    private DataDbContext _dataDbContext;
    private IJwtService _jwtService;

    public HomeController(DataDbContext dataDbContext, IJwtService jwtService)
    {
      _dataDbContext = dataDbContext;
      _jwtService = jwtService;
    }

    public JsonResult Index()
    {
      using (var unitOfWork = new UnitOfWork(_dataDbContext))
      {
        return Json(unitOfWork.Users.GetSomeUser(1));
      }
    }

    [HttpGet("token")]
    public string Token()
    {
      return _jwtService.GenerateToken();
    }

    [AllowAnonymous]
    public IActionResult Error()
    {
      return BadRequest("Error : Something wrong!");
    }
  }
}
