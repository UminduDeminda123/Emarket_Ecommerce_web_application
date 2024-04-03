using eMarket.Models;
using eMarket.Models.Data.Sevices;
using eMarket.Models.Data.Static;
using eTickets.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Controllers
{
    
    public class DealersController : Controller
    {
        private readonly IDealersService _service;

        public DealersController(IDealersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Dealers/Create
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
    
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio,Area,PhoneNumber")] Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return View(dealer);
            }
            await _service.AddAsync(dealer);
            return RedirectToAction(nameof(Index));
        }
    
       
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var dealerDetails = await _service.GetByIdAsync(id);

            if (dealerDetails == null) return View("NotFound");
            return View(dealerDetails);
        }
        //Get: dealer/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var dealerDetails = await _service.GetByIdAsync(id);
            if (dealerDetails == null) return View("NotFound");
            return View(dealerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio,Area,PhoneNumber")] Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return View(dealer);
            }
            await _service.UpdateAsync(id, dealer);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var dealerDetails = await _service.GetByIdAsync(id);
            if (dealerDetails == null) return View("NotFound");
            return View(dealerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealerDetails = await _service.GetByIdAsync(id);
            if (dealerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
