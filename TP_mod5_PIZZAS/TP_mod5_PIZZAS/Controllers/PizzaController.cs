using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_mod5_PIZZAS.Controllers
{
    public class PizzaController : Controller
    {

        private static List<Ingredient> ingredients;
        public List<Ingredient> Ingredients => ingredients ?? (ingredients = Pizza.IngredientsDisponibles);
        private static List<Pate> pates;
        public List<Pate> Pates => pates ?? (pates = Pizza.PatesDisponibles);

        // GET: Pizza
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
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

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
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

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
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
