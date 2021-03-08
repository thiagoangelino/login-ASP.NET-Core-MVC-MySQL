using LoginAspNetCoreMvcMySQL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAspNetCoreMvcMySQL.Controllers
{
    [Route("usuarios")]
    public class UsuarioController : Controller
    {
        DataContext db = new DataContext();


        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            if (ViewBag.login != null)
            {
                ViewBag.usuarios = db.Usuarios.ToList();
                return View("index");
            }
            else
            {
                return View("login");
            }
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Usuarios usuarios)
        {
            db.Usuarios.Add(usuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult delete(int id)
        {
            db.Usuarios.Remove(db.Usuarios.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult edit(int id)
        {
            return View("Edit", db.Usuarios.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Usuarios usuarios)
        {
            db.Entry(usuarios).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("buscar")]
        public IActionResult buscar(string nome)
        {
            ViewBag.usuarios = db.Usuarios.Where(x => x.Nome.Contains(nome));
            return View("index");
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string usuario, string senha)
        {
            ViewBag.login = db.Usuarios.Where(x => x.Usuario.Contains(usuario) && x.Senha.Contains(senha)).FirstOrDefault();


            if (ViewBag.login != null)
            {
                ViewBag.usuarios = db.Usuarios.ToList();
                return View("index");
            }
            else
            {
                ViewBag.Erro = "Dados Incorretos!";
                return View("login");
            }
        }
    }
}
