using ECommerceG02.Domian.Contacts;
using ECommerceG02.Domian.Models.Identity;
using ECommerceG02.Domian.Models.Orders;
using ECommerceG02.Domian.Models.Products;
using ECommerceG02.Presistence.Contexts;
using ECommerceG02.Presistence.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceG02.Presistence.Seed
{
    public class DataSeed : IDataSeed
    {
        private readonly StoreDbContext _context;
        private readonly StoreIdentityDbContext _identityContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeed(
            StoreDbContext context,
            StoreIdentityDbContext identityContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _identityContext = identityContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task DataSeedingAsync()
        {
            var pendingMigration = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigration.Any())
                await _context.Database.MigrateAsync();

            // Seed Brands
            if (!_context.ProductBrands.Any())
            {
                var productBrandData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\brands.json");
                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);
                if (productBrands != null && productBrands.Any())
                    _context.ProductBrands.AddRange(productBrands);
            }

            // Seed Types
            if (!_context.ProductTypes.Any())
            {
                var productTypeData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                if (productTypes != null && productTypes.Any())
                    _context.ProductTypes.AddRange(productTypes);
            }

            // Seed Products
            if (!_context.Products.Any())
            {
                var productData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products != null && products.Any())
                    _context.Products.AddRange(products);
            }

            await _context.SaveChangesAsync();

            // Seed Delivery Methods 
            if (!_context.DeliveryMethods.Any())
            {
                var dmData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\deliveryMethods.json");
                var dms = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
                if (dms != null && dms.Any())
                    _context.DeliveryMethods.AddRange(dms);

                await _context.SaveChangesAsync();
            }

            //// Seed Orders
            //if (!_context.Orders.Any())
            //{
            //    var orderData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\orders.json");
            //    var orders = JsonSerializer.Deserialize<List<Order>>(orderData);
            //    if (orders != null && orders.Any())
            //        _context.Orders.AddRange(orders);

            //    await _context.SaveChangesAsync();
            //}

            //// Seed Order Addresses
            //if (!_context.OrderAddresses.Any())
            //{
            //    var oaData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\orderAddresses.json");
            //    var oas = JsonSerializer.Deserialize<List<OrderAddress>>(oaData);
            //    if (oas != null && oas.Any())
            //        _context.OrderAddresses.AddRange(oas);

            //    await _context.SaveChangesAsync();
            //}

            //// Seed ProductItemOrdereds
            //if (!_context.ProductItemOrdereds.Any())
            //{
            //    var pioData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\productItemOrdereds.json");
            //    var pios = JsonSerializer.Deserialize<List<ProductItemOrdered>>(pioData);
            //    if (pios != null && pios.Any())
            //        _context.ProductItemOrdereds.AddRange(pios);

            //    await _context.SaveChangesAsync();
            //}

            //// Seed Order Items
            //if (!_context.OrderItems.Any())
            //{
            //    var oiData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerceG02.Presistence\Data\orderItems.json");
            //    var ois = JsonSerializer.Deserialize<List<OrderItem>>(oiData);
            //    if (ois != null && ois.Any())
            //        _context.OrderItems.AddRange(ois);

            //    await _context.SaveChangesAsync();
            //}
        }

    }
}
