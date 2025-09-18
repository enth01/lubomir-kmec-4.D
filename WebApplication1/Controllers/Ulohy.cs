using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Ulohy : Controller
    {
        // GET
        public IActionResult Uloha1()
        {
            var userList = new List<UserInfo>()
        {
            new UserInfo()
            {
                Name = "test 1",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "test 2",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "test 3",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "test 4",
                Email = "test@gmail.com",
            }
        };
            return View(userList);
        }

        // GET
        public IActionResult Uloha2()
        {
            return View();
        }

        public IActionResult Uloha3()
        {
            return View();
        }

        public IActionResult Uloha4()
        {
            var userList = new List<UserInfo>()
        {
            new UserInfo()
            {
                Name = "Matej",
                Surname = "B",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Martin",
                Surname = "M",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Damian",
                Surname = "D",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Lukas",
                Surname = "L",
                Email = "test@gmail.com",
            }
        };
            return View(userList);
        }


        public IActionResult Uloha5()
        {
            var userList = new List<UserInfo>()
        {
            new UserInfo()
            {
                Name = "Matej",
                Surname = "B",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Martin",
                Surname = "M",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Damian",
                Surname = "D",
                Email = "test@gmail.com",
            },
            new UserInfo()
            {
                Name = "Lukas",
                Surname = "L",
                Email = "test@gmail.com",
            }
        };
            return View(userList);
        }

        public IActionResult Uloha6()
        {
            return View();
        }

        public IActionResult Uloha7()
        {
            return View();
        }

        public IActionResult Uloha8()
        {
            return View();
        }
    }
}