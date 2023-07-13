using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mascotas_perdidas_codefirstV3;
using mascotas_perdidas_codefirstV3.Models;

namespace mascotas_perdidas_codefirstV3.Controllers
{
    public class MascotasController : Controller
    {
        private mascotasContexto db = new mascotasContexto();

        // GET: Mascotas
        public ActionResult Index()
        {
            var mascotas = db.Mascotas.Include(m => m.Especie);
            return View(mascotas.ToList());
        }

        // GET: Mascotas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }
        [Authorize]
        // GET: Mascotas/Create
        public ActionResult Create()
        {
            ViewBag.IDEspecie = new SelectList(db.Especies, "ID", "tipo");
            return View();
        }
        [Authorize]
        // POST: Mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDEspecie,nombre,edad,raza,fecha_extravio,lugar_extravio,descripcion,foto,nombre_dueño,correo_dueño,telefono_dueño")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEspecie = new SelectList(db.Especies, "ID", "tipo", mascota.IDEspecie);
            return View(mascota);
        }
        [Authorize]
        // GET: Mascotas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEspecie = new SelectList(db.Especies, "ID", "tipo", mascota.IDEspecie);
            return View(mascota);
        }
        [Authorize]
        // POST: Mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDEspecie,nombre,edad,raza,fecha_extravio,lugar_extravio,descripcion,foto,nombre_dueño,correo_dueño,telefono_dueño")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEspecie = new SelectList(db.Especies, "ID", "tipo", mascota.IDEspecie);
            return View(mascota);
        }
        [Authorize]
        // GET: Mascotas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }
        [Authorize]
        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
            db.Mascotas.Remove(mascota);
            db.SaveChanges();
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
