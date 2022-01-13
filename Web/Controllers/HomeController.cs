using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Settings;

namespace Web.Controllers;

public class HomeController : BaseController
{
    private readonly AppSettings _appSettings;

    public HomeController(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    [HttpGet]
    [Route(Routes.Home)]
    public ActionResult Index()
    {
        var pageModel = new PageModel(_appSettings);
        return View("~/Views/Home/Index.cshtml", pageModel);
    }
}