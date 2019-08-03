using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrinceVille.Models;

namespace PrinceVille.Controllers
{
    public class OwnerInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OwnerInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.OwnerInfoes.ToListAsync());
        }

        // GET: OwnerInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerInfo ownerInfo = await db.OwnerInfoes.FindAsync(id);
            if (ownerInfo == null)
            {
                return HttpNotFound();
            }
            return View(ownerInfo);
        }

        // GET: OwnerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ownerId,ownerCode,ownerFirstName,ownerLastName,Block,FlatNumber,HomePhone,MobileNumber,ownerEmail")] OwnerInfo ownerInfo, HttpPostedFileBase ownerPhoto)
        {
            if (ownerPhoto != null)
            {
                ownerInfo.ownerPhoto = new byte[ownerPhoto.ContentLength];
                ownerPhoto.InputStream.Read(ownerInfo.ownerPhoto, 0, ownerPhoto.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.OwnerInfoes.Add(ownerInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ownerInfo);
        }

        // GET: OwnerInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerInfo ownerInfo = await db.OwnerInfoes.FindAsync(id);
            if (ownerInfo == null)
            {
                return HttpNotFound();
            }
            return View(ownerInfo);
        }

        // POST: OwnerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ownerId,ownerCode,ownerFirstName,ownerLastName,Block,FlatNumber,HomePhone,MobileNumber,ownerEmail")] OwnerInfo ownerInfo, HttpPostedFileBase ownerPhoto)
        {
            if (ownerPhoto != null)
            {
                ownerInfo.ownerPhoto = new byte[ownerPhoto.ContentLength];
                ownerPhoto.InputStream.Read(ownerInfo.ownerPhoto, 0, ownerPhoto.ContentLength);
            }
            if (ModelState.IsValid)
            {
                db.Entry(ownerInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ownerInfo);
        }

        // GET: OwnerInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerInfo ownerInfo = await db.OwnerInfoes.FindAsync(id);
            if (ownerInfo == null)
            {
                return HttpNotFound();
            }
            return View(ownerInfo);
        }

        // POST: OwnerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OwnerInfo ownerInfo = await db.OwnerInfoes.FindAsync(id);
            db.OwnerInfoes.Remove(ownerInfo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
