using Business_address.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using Business_address.Models;

namespace Business_address.Controllers
{
    public class AddressController : Controller
    {
        private BAContextDB _dbContext = null;

        public AddressController()
        {
            this._dbContext = new BAContextDB();
        }

        // GET: Address
        public async Task<ActionResult> Index()
        {
            var addressList = await _dbContext.Addresses.ToListAsync();
            return View(addressList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Address address)
        {
            if (!ModelState.IsValid)
            {
                return View(address);
            }

            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }
    }
}