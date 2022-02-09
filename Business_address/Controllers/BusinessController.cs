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
    public class BusinessController : Controller
    {
        private BAContextDB _dbContext = null;

        public BusinessController()
        {
            this._dbContext = new BAContextDB();
        }

        // GET: Business
        public async Task<ActionResult> Index()
        {
            var businessList = await _dbContext.Businesses.ToListAsync();
            return View(businessList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Business business)
        {
            if (!ModelState.IsValid)
            {
                return View(business);
            }

            _dbContext.Businesses.Add(business);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var _business = await _dbContext.Businesses.FindAsync(id);
                if(_business != null)
                {
                    _dbContext.Entry(_business).State = EntityState.Deleted;
                    await _dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> BusinessClients(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            //var clientsBusiness = await _dbContext.Businesses.Include("Client").ToListAsync();
            var clientsBusiness =await _dbContext.Clients.Where(b => b.BusinessID == id).ToListAsync();

            return View(clientsBusiness);
        }
    }
}