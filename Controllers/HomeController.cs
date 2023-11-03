using Microsoft.AspNetCore.Mvc;
using Generador_de_Contraseñas_Aleatorias.Models;
using System;
using System.Text;

namespace Generador_de_Contraseñas_Aleatorias.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PasscodeModel passcodeModel = new PasscodeModel
            {
                Passcode = GenerateRandomPasscode()
            };
            int passcodeCount = IncrementPasscodeCount();
            ViewBag.PasscodeCount = passcodeCount;
            return View(passcodeModel);
        }

        [HttpPost]
        public IActionResult GenerateNewPasscode()
        {
            PasscodeModel passcodeModel = new PasscodeModel
            {
                Passcode = GenerateRandomPasscode()
            };
            int passcodeCount = IncrementPasscodeCount();
            ViewBag.PasscodeCount = passcodeCount;
            return View("Index", passcodeModel);
        }

        private string GenerateRandomPasscode()
        {
            Random random = new Random();
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder passcode = new StringBuilder();
            for (int i = 0; i < 14; i++)
            {
                passcode.Append(validChars[random.Next(0, validChars.Length)]);
            }
            return passcode.ToString();
        }

        private int IncrementPasscodeCount()
        {
            int passcodeCount = (int)(HttpContext.Session.GetInt32("PasscodeCount") ?? 0) + 1;
            HttpContext.Session.SetInt32("PasscodeCount", passcodeCount);
            return passcodeCount;
        }
    }
}