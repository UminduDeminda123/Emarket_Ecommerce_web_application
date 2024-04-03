using eMarket.Models.Data.Sevices;
using eMarket.Models.ViewModel;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync();
            return View(allProducts);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.BrandName.Contains(searchString) || n.Description.Contains(searchString)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }
        //GET: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
        public async Task<IActionResult> Create()
        {
           
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Dealers = new SelectList(productDropdownsData.Dealers, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
 
                ViewBag.Dealers = new SelectList(productDropdownsData.Dealers, "Id", "FullName");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        //GET: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Model = productDetails.Model,
                Description = productDetails.Description,
                Price = productDetails.Price,
                Capacity = productDetails.Capacity,
                ImageURL = productDetails.ImageURL,
                
                DealerIds = productDetails.Dealers_Products.Select(n => n.DealerId).ToList(),
            };

            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Dealers = new SelectList(productDropdownsData.Dealers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();


                ViewBag.Dealers = new SelectList(productDropdownsData.Dealers, "Id", "FullName");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}