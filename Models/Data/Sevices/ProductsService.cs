using eMarket.Models.ViewModel;
using eMarket.ViewModels;
using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Models.Data.Sevices
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Model = data.Model,
                Description = data.Description,
                Price = data.Price,
                BrandName = data.BrandName,
                Capacity = data.Capacity,
                ImageURL = data.ImageURL
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var dealerId in data.DealerIds)
            {
                var newDealerProduct = new Dealer_Product()
                {
                    ProductId = newProduct.Id,
                    DealerId = dealerId
                };
                await _context.Dealers_Products.AddAsync(newDealerProduct);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(am => am.Dealers_Products).ThenInclude(a => a.Dealer)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }
        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Dealers = await _context.Dealers.OrderBy(n => n.FullName).ToListAsync(),
              
                
            };

            return response;
        }
        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Model = data.Model;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.BrandName = data.BrandName;
                dbProduct.Capacity = data.Capacity;
               
                await _context.SaveChangesAsync();
            }

            //Remove existing products
            var existingDealersDb = _context.Dealers_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Dealers_Products.RemoveRange(existingDealersDb);
            await _context.SaveChangesAsync();

            //Add Product dealer
            foreach (var dealerId in data.DealerIds)
            {
                var newDealerProduct = new Dealer_Product()
                {
                    ProductId = data.Id,
                    DealerId = dealerId
                };
                await _context.Dealers_Products.AddAsync(newDealerProduct);
            }
            await _context.SaveChangesAsync();
        }
    }
}