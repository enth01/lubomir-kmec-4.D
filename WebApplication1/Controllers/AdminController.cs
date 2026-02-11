using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public AdminController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return RedirectToAction("Dashboard");

            await _productService.AddAsync(dto);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto dto)
        {
            if (!ModelState.IsValid) return RedirectToAction("Dashboard");

            await _productService.UpdateAsync(dto);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid publicId)
        {
            await _productService.DeleteAsync(publicId);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid publicId)
        {
            await _userService.DeleteAsync(publicId);
            return RedirectToAction("Dashboard");
        }
    }
}
