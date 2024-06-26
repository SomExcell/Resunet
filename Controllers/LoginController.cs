﻿using Microsoft.AspNetCore.Mvc;
using Resunet.BL.Auth;
using Resunet.ViewMapper;
using Resunet.ViewModels;

namespace Resunet.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthBL authBL;
        public LoginController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }
        [HttpGet]
        [Route("/login")]
        public IActionResult Index()
        {
            return View("Index",new LoginViewModel());
        }
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> IndexLoginAsync(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int id = await authBL.AuthenticateAsync(model.Email!, model.Password!, model.RememberMe == true);
                    return Redirect("/");
                }
                catch(Resunet.BL.AuthorizationException)
                {
                    ModelState.AddModelError("Email", "Имя или Email неверные");
                }
                
            }
            return View("Index",model);
        }
        
    }
}
