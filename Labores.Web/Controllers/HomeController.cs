﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labores.Entities;
using Labores.Context.Models;

namespace Labores.Web.Controllers
{
    public class HomeController : Controller
    {
        private LaboresContext db = new LaboresContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Labores.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Labor labor = db.Labores.Find(id);
            if (labor == null)
            {
                return HttpNotFound();
            }
            return View(labor);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Labor labor,Object nuevosMateriales)
        {
            if (ModelState.IsValid)
            {
                ActulizarContextState(labor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(labor);
        }

      
        public ActionResult AñadirMaterial() {
            ViewBag.Name = "nuevosMateriales";
            return PartialView("EditorTemplates/Material",new Material());
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Labor labor = db.Labores.Find(id);
            //db.Entry(labor).Collection(lb => lb.Materiales).Load();
            if (labor == null)
            {
                return HttpNotFound();
            }
            return View(labor);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Labor labor)
        {
            try {
                if (ModelState.IsValid)
                {
                    ActulizarContextState(labor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(labor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void ActulizarContextState(Labor labor)
        {
            ActulizarContextStateMateriales(labor);  
            if (labor.id == 0)  
            {
                db.Entry(labor).State = EntityState.Added;
            }
            else
            {
                db.Entry(labor).State = EntityState.Modified;
            }
          
        }

        private void ActulizarContextStateMateriales(Labor labor)
        {
            for (int i = 0; i < labor.Materiales.Count(); i++)
            {
                if (labor.Materiales[i].Id == 0)
                {
                    db.Entry(labor.Materiales[i]).State = EntityState.Added;
                }
                else
                {
                    db.Entry(labor.Materiales[i]).State = EntityState.Modified;
                }
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Labor labor = db.Labores.Find(id);
            if (labor == null)
            {
                return HttpNotFound();
            }
            return View(labor);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labor labor = db.Labores.Find(id);
            db.Labores.Remove(labor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}