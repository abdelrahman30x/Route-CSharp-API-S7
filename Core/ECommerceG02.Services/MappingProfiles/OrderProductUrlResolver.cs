using AutoMapper;
using ECommerceG02.Domian.Models.Orders;
using ECommerceG02.Shared.DTOs.OrderDto_s;
using Microsoft.Extensions.Configuration;

namespace ECommerceG02.Services.MappingProfiles
{
    public class OrderProductUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
            {
                return $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.Product.PictureUrl}";
            }
            return null;
        }
    }
}
