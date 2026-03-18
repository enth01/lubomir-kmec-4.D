using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;

namespace biznis.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICartItemRepository _cartRepo;
        private readonly IUserAddressRepository _addressRepo;

        public OrderService(IOrderRepository orderRepo, ICartItemRepository cartRepo, IUserAddressRepository addressRepo)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
            _addressRepo = addressRepo;
        }

        public async Task<List<OrderDto>> GetByUserAsync(Guid userPublicId)
        {
            var orders = await _orderRepo.GetByUserPublicIdAsync(userPublicId);
            return orders.Select(o => new OrderDto
            {
                PublicId = o.PublicId,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
                Items = o.Items.Select(i => new CartItemDto
                {
                    PublicId = i.PublicId,
                    UserPublicId = i.UserId,
                    ProductPublicId = i.Product.PublicId,
                    ProductName = i.Product.Name,
                    ProductPrice = i.Product.Price,
                    Quantity = i.Quantity
                }).ToList(),
                AddressPublicId = o.Address.PublicId
            }).ToList();
        }

        public async Task<bool> CreateAsync(OrderCreateDto dto)
        {
            var cartItems = await _cartRepo.GetByUserPublicIdAsync(dto.UserPublicId);
            if (cartItems.Count == 0) return false;

            var address = await _addressRepo.GetByPublicIdAsync(dto.AddressPublicId);
            if (address == null) return false;

            var order = new OrderEntity
            {
                PublicId = Guid.NewGuid(),
                UserPublicId = dto.UserPublicId,
                Items = cartItems,
                TotalPrice = cartItems.Sum(i => i.Product.Price * i.Quantity),
                Status = StatusEnum.Processing,
                AddressId = address.Id,
                Address = address
            };

            await _orderRepo.CreateAsync(order);
            await _orderRepo.SaveChangesAsync();
            return true;
        }
    }
}