using System;
using Resunet.BL.Auth;
using Microsoft.AspNetCore.Mvc;
using Resunet.ViewModels;
using Resunet.ViewMapper;

namespace Resunet.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthBL authBl;

        public RegisterController(IAuthBL authBl)
        {
            this.authBl = authBl;
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return View("Index", new RegisterViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> IndexSaveAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await authBl.CreateUserAsync(AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/");
            }

            return View("Index", model);
        }
    }
}

