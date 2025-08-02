﻿using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinic.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServices.LogIn(login);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Invalid login attempt");
                return View(login);
            }
            return View(login);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register()
        {
            var roles = await _userServices.GetAllRoles();

            var model = new RegisterViewModel
            {
                RolesList = roles
            };
            ViewBag.Roles = roles.Select(_ => new SelectListItem
            {
                Value = _,
                Text = _
            }).ToList();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            //if (!User.Identity!.IsAuthenticated)
            //    return Unauthorized("Access Denied.");

            if (ModelState.IsValid)
            {
                var result = await _userServices.RegisterUser(register);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _userServices.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
