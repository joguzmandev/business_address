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
    public class ClientController : Controller
    {
        private BAContextDB _dbContext = null;

        public ClientController()
        {
            this._dbContext = new BAContextDB();
        }

        // GET: Client
        public async Task<ActionResult> Index()
        {
            var clientsList = await _dbContext.Clients.Include("Business").ToListAsync();
            return View(clientsList);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Businesses = await GetBusinessList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? clientId)
        {
            if (clientId.HasValue)
            {
                var clientFound = _dbContext.Clients.Where(c => c.Id == clientId).First();
                if (clientFound != null)
                {
                    ViewBag.Businesses = await GetBusinessList();
                    return View(clientFound);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }

            _dbContext.Entry(client).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var _business = await _dbContext.Clients.FindAsync(id);
                if (_business != null)
                {
                    _dbContext.Entry(_business).State = EntityState.Deleted;
                    await _dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddressesClient(int? clientId)
        {

            if (!clientId.HasValue)
            {
                return RedirectToAction("Index");
            }

            var addressesClientList = await _dbContext.Addresses.Where(c => c.ClientID == clientId).ToListAsync();


            return View(addressesClientList);
        }

        private async Task<List<SelectListItem>> GetBusinessList()
        {
            var businessList =  await (from bu in _dbContext.Businesses
                                 select new SelectListItem()
                                 {
                                     Text = bu.Name,
                                     Value = bu.Id.ToString()
                                 }).ToListAsync();

            return businessList;

        }

    }
}