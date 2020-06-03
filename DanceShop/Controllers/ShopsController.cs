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
    public class ShopsController : Controller
    {
        //private DanceShopContext db = new DanceShopContext();

        public ShopsController() { }

        IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: Shops
        public ActionResult Index(string minPrice, string maxPrice)
        {
            _shopService.FindAllEquipment();
            int min = 0;
            int max = 0;
            int.TryParse(minPrice, out min);
            int.TryParse(maxPrice, out max);

            if (minPrice != null && maxPrice != null && !maxPrice.Trim().Equals("") && !minPrice.Equals(""))
            {
                IEnumerable<Shop> model = _shopService.FindBetween(min, max);
                return View(model);

            }
            else if ((minPrice == null || minPrice.Equals("")) && (maxPrice != null && !maxPrice.Equals("")))
            {
                IEnumerable<Shop> model = _shopService.FindCheaper(max);
                return View(model);
            }
            else if ((maxPrice == null || maxPrice.Equals("")) && (minPrice != null && !minPrice.Equals("")))
            {
                IEnumerable<Shop> model = _shopService.FindExpensive(min);
                return View(model);
            }
            else
            {
                IEnumerable<Shop> model = _shopService.FindAll();
                return View(model);
            }
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = _shopService.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create(int id)
        {
            ViewBag.CustomerID = new SelectList(_shopService.FindAllCustomers(), "Id", "Name");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "Id,Location,CustomerID,CustomerName,EquipmentName,EquipmentID,EquipmentType,Price")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Equipment Equipment = _shopService.FindAllEquipmentPerId(id);

                shop.EquipmentID = Equipment.Id;
                Customer t = _shopService.FindAllCustomersPerId(shop.CustomerID);
                shop.CustomerName = t.Name;
                shop.Price = Equipment.Price;
                shop.EquipmentType = Equipment.EquipmentType;
                _shopService.Add(shop);

                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: Shops/Edit/5
        //public ActionResult Edit(int? id)
        //{
           // if (id == null)
           // {
           //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          //  }
          //  Shop shop = db.Shops.Find(id);
          //  if (shop == null)
          //  {
            //    return HttpNotFound();
           // }
           // return View(shop);
//}
    
        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
     //   [HttpPost]
     //   [ValidateAntiForgeryToken]
      //  public ActionResult Edit([Bind(Include = "Id,Location,CustomerID,CustomerName,EquipmentName,EquipmentID,EquipmentType,Price")] Shop shop)
     //   {
      //      if (ModelState.IsValid)
      //      {
       //         db.Entry(shop).State = EntityState.Modified;
       //         db.SaveChanges();
       //         return RedirectToAction("Index");
        //    }
       //     return View(shop);
       // }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = _shopService.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = _shopService.Find(id);
            _shopService.Delete(shop);
            return RedirectToAction("Index");
        }

        public ActionResult Search(string data)
        {

            var Shops = _shopService.FindAll();

            if (!String.IsNullOrEmpty(data))
            {
                var separate = Shops.Where(s => s.EquipmentType.Contains(data));
                foreach (var i in separate)
                {
                    ViewBag.Name = i.EquipmentType;
                }
                return View(separate);
            }
            return View();


        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
