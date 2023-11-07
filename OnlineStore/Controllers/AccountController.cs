using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;

        public AccountController(IUserAppService userAppService , SignInManager<User> signInManager, Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            _userAppService = userAppService;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserViewModel user, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,

                };
                var resault = await _userAppService.LogIn(userDto, cancellationToken);
                if (resault.Succeeded)
                {
                    var usern = await _userAppService.FindUserByName(userDto.UserName,cancellationToken);
                    var roles = await _userAppService.GetRole(usern.Id ,cancellationToken);
                    foreach (var role in roles)
                    {
                        if (role == "Admin")
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        if (role == "Customer")
                        {
                            return RedirectToAction("Index", "Home", new { area = "Customer" });
                        }
                        if (role == "Seller")
                        {
                            return RedirectToAction("Index", "Home", new { area = "Seller" });
                        }
                    }

                }
                ModelState.AddModelError("", "اطلاعات وارد شده صحیح نمیباشد");



            }
            return View(user);


        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SignUp(UserViewModel user, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    IsSeller = user.IsSeller,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,

                };
                var resault = await _userAppService.SignUp(userDto, cancellation);
                if (resault.Succeeded)
                {
                    return RedirectToAction("LogIn", "Account");
                }
                foreach (var error in resault.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            foreach (var key in ModelState.Keys)
            {
                var modelStateEntry = ModelState[key];
                if (modelStateEntry.Errors.Any())
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        // Log or inspect the error message as needed
                    }
                }
            }

            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut(CancellationToken cancellationToken)
        {
            await _userAppService.LogOut(cancellationToken);
            return RedirectToAction("Index", "Home");
        }
    }
}
