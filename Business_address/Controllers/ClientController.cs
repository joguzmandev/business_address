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
            var business =await (from bu in _dbContext.Businesses
                           select new SelectListItem()
                           {
                               Text = bu.Name,
                               Value = bu.Id.ToString()
                           }).ToListAsync();

            ViewBag.Businesses = business;
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

    }
}