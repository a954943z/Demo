using DEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Controllers
{
    public class AccountController : Controller
    {
        private TrueDB _TrueDB;

        public AccountController(TrueDB trueDB)
        {
            _TrueDB = trueDB;
        }

        public IActionResult LoginView()
        {
            return View();
        }
        public IActionResult RegisterView()
        {
            return View();
        }

        public bool Login([FromBody] Models.ViewModels.LoginViewModel loginViewModel)
        {
            var userlogin = _TrueDB.users.FirstOrDefault(x => x.Name == loginViewModel.Name && x.Password==loginViewModel.Password);
            if (userlogin!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Register([FromBody] Models.ViewModels.RegisterViewModel registerViewModel)
        {
            var userRegister = _TrueDB.users.FirstOrDefault(x => x.Name == registerViewModel.Name);
            if(userRegister==null)
            {
                _TrueDB.users.Add(new Models.User()
                {
                    Name = registerViewModel.Name,
                    Password = registerViewModel.Password
                });
                _TrueDB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
