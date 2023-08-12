using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using mascotas_perdidas_codefirstV3;
using mascotas_perdidas_codefirstV3.Models;

namespace mascotas_perdidas_codefirstV3.Controllers
{
    public class MascotasController : Controller
    {
        Mascota_UsuarioController mascota_usuarioController = new Mascota_UsuarioController();

        private mascotasContexto db = new mascotasContexto();

        // GET: Mascotas
        public ActionResult Mascotas_Perdidas()
        {
            var mascotas = db.Mascotas.Include(m => m.Especie);


            var renderMascota =
       from mascota in mascotas
       where mascota.encontrada == false
       select mascota;


            return View(renderMascota.ToList());
        }

        // GET: Mascotas/Mis_Mascotas
        public ActionResult Mis_Mascotas()
        {

            return View(mascota_usuarioController.ReturnMascotas(User.Identity.Name).ToList());
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
        public ActionResult Create([Bind(Include = "ID,IDEspecie,nombre,edad,raza,fecha_extravio,lugar_extravio,descripcion,nombre_dueño,correo_dueño,telefono_dueño, Imagen")] Mascota mascota)
        {

            HttpPostedFileBase FileBase = Request.Files[0];

            if (FileBase.ContentLength == 0) {

                ModelState.AddModelError("Imagen", "Es necesario seleccionar una imagen");
            }
            else{
                if (FileBase.FileName.EndsWith(".jpg"))
                {

                    WebImage image = new WebImage(FileBase.InputStream);

                    mascota.Imagen = image.GetBytes();

                }
                else {

                    ModelState.AddModelError("Imagen", "El sistema unicamente acepta imagenes con formato JPG");
                
                }
                
            }

           

            Mascota_Usuario mascota_Usuario = new Mascota_Usuario();

            mascota_Usuario.IDMascotas = mascota.ID;
            mascota_Usuario.Mascota = mascota;
            mascota_Usuario.nombreUsuario = User.Identity.Name;

            Mascota_UsuarioController mascota_usuarioController = new Mascota_UsuarioController();

            mascota_usuarioController.Create(mascota_Usuario);

            if (ModelState.IsValid)
            {
                db.Mascotas.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Mis_Mascotas");
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
        public ActionResult Edit([Bind(Include = "ID,IDEspecie,nombre,edad,raza,fecha_extravio,lugar_extravio,descripcion,nombre_dueño,correo_dueño,telefono_dueño,encontrada, Imagen")] Mascota mascota)
        {

            //byte[] imagenActual = null;
            Mascota _mascota = new Mascota();



            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength == 0)
            {
                _mascota = db.Mascotas.Find(mascota.ID);
                mascota.Imagen = _mascota.Imagen;
            }
            else {

                if (FileBase.FileName.EndsWith(".jpg"))
                {

                    WebImage image = new WebImage(FileBase.InputStream);

                    mascota.Imagen = image.GetBytes();

                }
                else
                {

                    ModelState.AddModelError("Imagen", "El sistema unicamente acepta imagenes con formato JPG");

                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(_mascota).State = EntityState.Detached;
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Mis_Mascotas");
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
            return RedirectToAction("Mis_Mascotas");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
        // GET: Mascotas/Mascotas_Encontradas/8
        public ActionResult Mascotas_Encontradas(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Mascotas.Find(id).encontrada = true;
            db.SaveChanges();

            Mascota mascota = db.Mascotas.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }

            

            ViewBag.IDEspecie = new SelectList(db.Especies, "ID", "tipo", mascota.IDEspecie);
            return View(mascota);

            
            
        }
        */


        // GET: Mascotas/Mascotas_Encontradas
        public ActionResult Mascotas_Encontradas()
        {
            var mascotas = db.Mascotas.Include(m => m.Especie);


            var renderMascota =
       from mascota in mascotas
       where mascota.encontrada == true
       select mascota;


            return View(renderMascota.ToList());
        }

        public ActionResult getImage(int id)
        {
            Mascota mascota = db.Mascotas.Find(id);
             
            if (mascota.Imagen == null) {
                return View("");


                    }
            else { 

            byte[] byteImage = mascota.Imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
            }
        }
        }
    }
