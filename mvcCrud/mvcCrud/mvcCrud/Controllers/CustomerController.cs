using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcCrud.Models;
using System.Data.Entity;

namespace mvcCrud.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/
        public ActionResult Index()
        {
            using (Dbmodels dbmodel = new Dbmodels())
            {
                return View(dbmodel.customers.ToList());
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (Dbmodels dbmodel = new Dbmodels())
            {
                return View(dbmodel.customers.Where(X => X.Id == id).FirstOrDefault());
            }
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(customer customer)
        {
            try
            {
                using (Dbmodels dbmodel = new Dbmodels())
                {
                    dbmodel.customers.Add(customer);
                    dbmodel.SaveChanges();
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (Dbmodels dbmodel = new Dbmodels())
            {
                return View(dbmodel.customers.Where(X => X.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, customer customer)
        {
            try
            {
                using (Dbmodels dbmodel = new Dbmodels())
                {
                    dbmodel.Entry(customer).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                    
                }
                // TODO: Add update logic here
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (Dbmodels dbmodel = new Dbmodels())
            {
                return View(dbmodel.customers.Where(X => X.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (Dbmodels dbmodel = new Dbmodels())
                {
                    customer customer = dbmodel.customers.Where(X => X.Id == id).FirstOrDefault();
                    dbmodel.customers.Remove(customer);
                    dbmodel.SaveChanges();
                }

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