using GestioneHotelApp.Models;
using GestioneHotelApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace GestioneHotelApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserDao _userDao;

        public AccountController(UserDao userDao)
        {
            _userDao = userDao;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _userDao.GetUserByUsername(username);

            if (user != null && VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                // Creare i claims di autenticazione
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                // Creare il principal
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                // Creare il cookie di autenticazione
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Reindirizzare alla home page
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Username o password non validi.";
            return View();
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash, string storedPasswordSalt)
        {
            // Convertire il salt e la password hashati in byte
            byte[] saltBytes = Convert.FromBase64String(storedPasswordSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedPasswordHash);

            // Generare l'hash della password inserita utilizzando il salt memorizzato
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] enteredHashBytes = pbkdf2.GetBytes(32); // 32 byte per SHA256

                // Confrontare i byte degli hash
                for (int i = 0; i < storedHashBytes.Length; i++)
                {
                    if (enteredHashBytes[i] != storedHashBytes[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
