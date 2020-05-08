using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNet.DataAccess.Models;
using QuizNet.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using QuizNet.DataAccess;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace QuizNet.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;
        private readonly IHostEnvironment _hostEnv;
        private readonly EFDbContext _context;

        public HomeController(ILogger<HomeController> logger, 
            IMemoryCache cache,
            IHostEnvironment hostEnv,
            EFDbContext context)
        {
            _logger = logger;
            _cache = cache;
            _hostEnv = hostEnv;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cache1()
        {
            if (!_cache.TryGetValue("Current time", out DateTime result))
            {
                result = DateTime.Now;
                _cache.Set("Current time", result, TimeSpan.FromSeconds(5));
            }

            return View("Cache", result);
        }

        public IActionResult Cache2()
        {
            var cacheItem = _cache.GetOrCreate("Current time", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(8);
                return DateTime.Now;
            });

            return View("Cache", cacheItem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> NewFileHelper()
        {
            var images = await _context.Images.ToListAsync();
            return View(images);
        }

        public IActionResult NewFile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewFile(ImageViewModel imageVM)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(imageVM);

                Image image = new Image
                {
                    Title = imageVM.Title,
                    ImageDescription = imageVM.ImageDescription,
                };
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction("NewFileHelper");
            }
            return View();
        }

        private string UploadedFile(ImageViewModel imageVM)
        {
            string uniqueFileName = null;
            if (uniqueFileName != null)
            {
                string uploadFolder = Path.Combine(_hostEnv.ContentRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imageVM.ImageProfile.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath,FileMode.Create))
                {
                    imageVM.ImageProfile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
