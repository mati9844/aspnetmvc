using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Areas.Identity.Data;
using Application.Data;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationContext context, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View("Views/Home/Index.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(ApplicationUser user, IFormFile file)
        {
            user = await _userManager.GetUserAsync(User);
            if (file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    if (memoryStream.Length < 2097152)
                    {
                        user.Photo = memoryStream.ToArray();
                    }
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            return Index();
        }
    }
}
