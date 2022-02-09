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
            var clientsList = await _dbContext.Clients.ToListAsync();
            return View(clientsList);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}