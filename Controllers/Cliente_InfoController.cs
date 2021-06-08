using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prova_Q2_Laercio_POO.Models;

namespace Prova_Q2_Laercio_POO.Controllers
{
    public class Cliente_InfoController : Controller
    {
        private CLIENTESEntities db = new CLIENTESEntities();

        // GET: Cliente_Info
        public ActionResult Index()
        {
            return View(db.Cliente_Info.ToList());
        }

        // GET: Cliente_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Info cliente_Info = db.Cliente_Info.Find(id);
            if (cliente_Info == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Info);
        }

        // GET: Cliente_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente_Info/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cli_Id_Cliente,cli_NomeCliente,cli_Celular,cli_Cidade,cli_Estado")] Cliente_Info cliente_Info)
        {
            if (ModelState.IsValid)
            {
                db.Cliente_Info.Add(cliente_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente_Info);
        }

        // GET: Cliente_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Info cliente_Info = db.Cliente_Info.Find(id);
            if (cliente_Info == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Info);
        }

        // POST: Cliente_Info/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cli_Id_Cliente,cli_NomeCliente,cli_Celular,cli_Cidade,cli_Estado")] Cliente_Info cliente_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente_Info);
        }

        // GET: Cliente_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente_Info cliente_Info = db.Cliente_Info.Find(id);
            if (cliente_Info == null)
            {
                return HttpNotFound();
            }
            return View(cliente_Info);
        }

        // POST: Cliente_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente_Info cliente_Info = db.Cliente_Info.Find(id);
            db.Cliente_Info.Remove(cliente_Info);
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
