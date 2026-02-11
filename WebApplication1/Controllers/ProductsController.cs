using biznis.Interfaces.Services;
using Common.Dto;
using Common.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Products(CategoryEnum? category)
        {
            var products = await _service.GetAll(category);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(Guid productId, Guid userId, string productName, float productPrice)
        {
            var cartItemDto = new CartItemDto() { productPublicId = productId, userPublicId = userId, productName = productName, productPrice = productPrice };

            await _service.AddToBasket(cartItemDto);

            return RedirectToAction("Products");
        }

        [HttpPost]
        public async Task<IActionResult> Cart(Guid userPublicId)
        {
            var allCartItems = await _service.GetAllCartItems(userPublicId);
            return View(allCartItems);
        }
    }
}
