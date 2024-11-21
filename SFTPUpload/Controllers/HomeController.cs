using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SFTPUpload.Models;
using SFTPUpload.Services;
using SFTPUpload.ViewModels;

namespace SFTPUpload.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SFTPService _SFTPService;

    public HomeController(ILogger<HomeController> logger, SFTPService SFTPService)
    {
        _logger = logger;
        _SFTPService = SFTPService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(UploadFileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            @ViewBag.Status = false;
            @ViewData["Message"] = "Error uploading file";
            return RedirectToAction("Index");
        }

        var response = _SFTPService.UploadFile(model.File, model.File.FileName);
        
        @ViewBag.Status = response.Status;
        @ViewData["Message"] = response.Message;

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