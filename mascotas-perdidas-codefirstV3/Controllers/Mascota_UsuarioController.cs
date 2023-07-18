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
    public class Mascota_UsuarioController : Controller
    {
        private mascotasContexto db = new mascotasContexto();

        // GET: Mascota_Usuario
        public ActionResult Index()
        {
            var mascotas_Usuarios = db.Mascotas_Usuarios.Include(m => m.Mascota);
            return View(mascotas_Usuarios.ToList());
        }

        // GET: Mascota_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota_Usuario mascota_Usuario = db.Mascotas_Usuarios.Find(id);
            if (mascota_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(mascota_Usuario);
        }

       
        public List<int> DetailsUserMascota(string usuario)
        {
            List<int> idMascotas = new List<int>();

            foreach(var item in db.Mascotas_Usuarios)
            {
                if (item.nombreUsuario == usuario)
                {
                    idMascotas.Add(item.IDMascotas);
                }
                
            }


            return idMascotas;
        }

        // GET: Mascota_Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IDMascotas = new SelectList(db.Mascotas, "ID", "nombre");
            return View();
        }

        // POST: Mascota_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nombreUsuario,IDMascotas")] Mascota_Usuario mascota_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Mascotas_Usuarios.Add(mascota_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMascotas = new SelectList(db.Mascotas, "ID", "nombre", mascota_Usuario.IDMascotas);
            return View(mascota_Usuario);
        }

        // GET: Mascota_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota_Usuario mascota_Usuario = db.Mascotas_Usuarios.Find(id);
            if (mascota_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMascotas = new SelectList(db.Mascotas, "ID", "nombre", mascota_Usuario.IDMascotas);
            return View(mascota_Usuario);
        }

        // POST: Mascota_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nombreUsuario,IDMascotas")] Mascota_Usuario mascota_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMascotas = new SelectList(db.Mascotas, "ID", "nombre", mascota_Usuario.IDMascotas);
            return View(mascota_Usuario);
        }

        // GET: Mascota_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota_Usuario mascota_Usuario = db.Mascotas_Usuarios.Find(id);
            if (mascota_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(mascota_Usuario);
        }

        // POST: Mascota_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota_Usuario mascota_Usuario = db.Mascotas_Usuarios.Find(id);
            db.Mascotas_Usuarios.Remove(mascota_Usuario);
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
