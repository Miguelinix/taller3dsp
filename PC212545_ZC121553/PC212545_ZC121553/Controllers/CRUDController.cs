using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
    
//IMPORTAR LA CARPETA  Models
using PC212545_ZC121553.Models;


namespace PC212545_ZC121553.Controllers
{
    public class CRUDController : Controller
    {
        //CREAMOS LA VARIABLE ModeloBandas
        banda modelo;

        public CRUDController()
        {   
            //INICIALIZAMOS LA VARIABLE COMO OBJETO
            modelo = new banda();
        }

        // GET: Lista
        public ActionResult Lista()
        {

            //LLAMAMOS AL MÉTODO GetUsuarios() Y LO ALMACENAMOS EN LA VARIABLE Listacrud
            List<banda> Listacrud = modelo.GetUsuarios();
            return View(Listacrud);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(String BANDA, String INTEGRANTES, String ALBUM, String SENCILLOS)
        {
            modelo.InsertarUsuarios(BANDA, INTEGRANTES, ALBUM, SENCILLOS);

            return RedirectToAction("Lista");
        }
        // GET: Delete
        public ActionResult Delete(int id)
        {
            modelo.EliminarUsuarios(id);
            return RedirectToAction("Listacrud");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            banda user = modelo.DetallesUsuarios(id);
            return View(user);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(int id, String BANDA, String INTEGRANTES, String ALBUM, String SENCILLOS)
        {
            modelo.ModificarUsuarios(id, BANDA, INTEGRANTES, ALBUM, SENCILLOS);
            {

                return RedirectToAction("Listacrud");
            }
        }

        //GET: Details
        public ActionResult Details(int id)
        {
            banda user = modelo.DetallesUsuarios(id);

            return View(user);
        }
    }
}