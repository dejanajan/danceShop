using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contracts.Services;
using Data;
using Model;

namespace DanceShop.Controllers
{
    public class EquipmentsController : Controller
    {
        //private DanceShopContext db = new DanceShopContext();

        public EquipmentsController() { }

        IDomainEntityServices<Equipment> _equipmentService;

        public EquipmentsController(IDomainEntityServices<Equipment> equipmentService)
        {
            _equipmentService = equipmentService;

        }

        // GET: Equipments
        public ActionResult Index()
        {
            return View(_equipmentService.FindAll());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = _equipmentService.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EquipmentType,Producer,Country,Telephone,Email,Price")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _equipmentService.Add(equipment);
                return RedirectToAction("Index");
            }

            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = _equipmentService.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EquipmentType,Producer,Country,Telephone,Email,Price")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(equipment).State = EntityState.Modified;
                _equipmentService.Edit(equipment);
                return RedirectToAction("Index");
            }
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = _equipmentService.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = _equipmentService.Find(id);
            _equipmentService.Delete(equipment);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
