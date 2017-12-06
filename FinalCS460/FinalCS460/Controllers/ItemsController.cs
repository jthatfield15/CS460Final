using FinalCS460.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCS460.Controllers
{
    public class ItemsController : Controller
    {
        private ItemsContext db = new ItemsContext();

        // GET: /
        // GET: Items
        // GET: Items/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Items/Items
        public ActionResult Items()
        {
            var items = db.ITEMS;
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            var item = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault();
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            var sellers = db.SELLERS;
            return View(sellers);
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ITEM item = db.ITEMS.Create();

                //var tempSeller = collection["sellerName"];

                //Debug.WriteLine(tempSeller);

                //var tempID = db.SELLERS.Where(s => s.SellerName == tempSeller).FirstOrDefault().SellerID;

                //Debug.WriteLine(tempID);

                item.ItemName = collection["itemName"];
                item.ItemDesc = collection["itemDesc"];
                //item.SellerName = collection["sellerName"];
                item.SellerID = 1;
                //Debug.WriteLine(tempID);
                //item.SellerID = collection["sellerID"];

                db.ITEMS.Add(item);
                db.SaveChanges();

                return RedirectToAction("Items");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.itemName = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault().ItemName;
            ViewBag.itemDesc = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault().ItemDesc;
            return View();
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var itemToUpdate = db.ITEMS.Find(id);

                itemToUpdate.ItemName = collection["itemName"];
                itemToUpdate.ItemDesc = collection["itemDesc"];

                db.SaveChanges();

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            var item = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault();

            ViewBag.itemName = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault().ItemName;
            ViewBag.itemDesc = db.ITEMS.Where(i => i.ItemID == id).FirstOrDefault().ItemDesc;

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var itemToBeDeleted = db.ITEMS.Find(id);

                db.ITEMS.Remove(itemToBeDeleted);
                db.SaveChanges();

                return RedirectToAction("Items");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Bid
        public ActionResult Bid()
        {
            var items = db.ITEMS;
            
            return View(items);
        }

        public ActionResult CreateBid(int id)
        {
            var item = db.ITEMS.Find(id);
            
            return View(item);
        }

        [HttpPost]
        public ActionResult CreateBid(int id, FormCollection collection)
        {
            try
            {
                BID bid = db.BIDS.Create();

                bid.ItemID = id;
                bid.BuyerID = 1;
                bid.Price = collection["price"];
                bid.BidDateTime = DateTime.Now;

                Debug.WriteLine(bid.ItemID);
                Debug.WriteLine(bid.Price);
                Debug.WriteLine(bid.BidDateTime);

                db.BIDS.Add(bid);
                db.SaveChanges();

                return RedirectToAction("items");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult getDetails(int id)
        {
            var bids = db.ITEMS.Find(id).BIDS.ToList().OrderBy(b => b.Price).ToList();

            string[] allBids = new string[bids.Count()];
            for (int i = 0; i < allBids.Length; i++)
            {
                allBids[i] = $"<ul>{db.BIDS.Find(bids[i].BUYER.BuyerName)} at {db.BIDS.Find(bids[i].Price)}</ul>";
            }

            var data = new
            {
                arr = allBids
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
