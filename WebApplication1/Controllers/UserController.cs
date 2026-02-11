using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController(IUserService service) : Controller
    {
        private readonly IUserService _service = service;

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _service.CreateAsync(dto);
            Response.Cookies.Append("UserPublicId", user.PublicId.ToString());
            return RedirectToAction("Profile");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _service.AuthenticateAsync(dto.Email, dto.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(dto);
            }

            Response.Cookies.Append("UserPublicId", user.PublicId.ToString());
            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserPublicId");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Profile()
        {
            if (!Request.Cookies.TryGetValue("UserPublicId", out var id))
                return RedirectToAction("Login");

            var user = await _service.GetDtoByPublicIdAsync(Guid.Parse(id));
            return View(user);
        }

        public IActionResult Edit() => View();

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto dto)
        {
            var id = Guid.Parse(Request.Cookies["UserPublicId"]!);
            await _service.UpdateAsync(id, dto);
            return RedirectToAction("Profile");
        }

        public IActionResult DeleteConfirm() => View();

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            var id = Guid.Parse(Request.Cookies["UserPublicId"]!);
            await _service.DeleteAsync(id);
            Response.Cookies.Delete("UserPublicId");
            return RedirectToAction("Index", "Home");
        }
    }
}
