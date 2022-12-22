using examen_backend_AbrahamHernandezGonzalez.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examen_frontend_AbrahamHernandezGonzalez.Controllers
{
    public class UsuariosController : Controller
    {
        
        
        // GET: Usuarios
        public List<Usuarios> _lsUsuarios = new List<Usuarios>();
        API_Usuarios Api_Usuarios = new API_Usuarios();
        public Usuarios Usario = new Usuarios();

        public ActionResult Index()
        {
            _lsUsuarios = Api_Usuarios.ConsultarTodos();

            return View(_lsUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usario = Api_Usuarios.Consultar(id);
            return View(Usario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios User)
        {
            try
            {
                // TODO: Add insert logic here
                Api_Usuarios.Agregar(User);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usario = Api_Usuarios.Consultar(id);
            return View(Usario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuarios collection)
        {
            try
            {
                Api_Usuarios.Actualizar(collection);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usario = Api_Usuarios.Consultar(id);
            return View(Usario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Api_Usuarios.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
