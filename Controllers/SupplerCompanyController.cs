using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using ExecuteIdentityFramework.ComputerStore.DAO;
using ExecuteIdentityFramework.ComputerStore;
using ExecuteIdentityFramework.DAO;

namespace ExecuteIdentityFramework.Controllers
{
    public class SupplerCompanyController : Controller
    {
        private MongoContext context = new MongoContext();
      
        // GET: SupplerCompany
        public ActionResult Index()
        {
            var supplercompanies = context.GetAllSupplerCompanies();
            return View(supplercompanies);
        }

        // GET: SupplerCompany/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplerCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplerCompany/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplerCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplerCompany/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplerCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplerCompany/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
