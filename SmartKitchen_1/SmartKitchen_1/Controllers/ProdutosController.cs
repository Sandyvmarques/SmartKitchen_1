using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartKitchen_1.Models;
using SmartKitchen_1.Models;


namespace SmartKitchen_1.Controllers
{
    public class ProdutosController : Controller
    {
		private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var listaDeProdutos = db.Produtos.OrderBy(p => p.Categoria);
            return View(listaDeProdutos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
			Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
				return RedirectToAction("Index");
			}
			return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
           // ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")] Produtos produtos , HttpPostedFileBase [] uploadImagem)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
			Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
				return RedirectToAction("Index");
			}
			//ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
			return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prod_ID,NomeProduto,Descricao,IVAVenda,PrecoVenda,Stock,CategoriasFK")] Produtos produtos)
        {
			if (ModelState.IsValid)
			{

				db.Entry(produtos).State = EntityState.Modified;
				db.SaveChanges();


			}
            //ViewBag.CategoriasFK = new SelectList(db.Categorias, "Cat_ID", "NomeCateg", produto.CategoriasFK);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return RedirectToAction("Index");
			}
			Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
				return RedirectToAction("Index");
			}
			return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produto = db.Produtos.Find(id);
			try
			{
				db.Produtos.Remove(produto);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex) {
				ModelState.AddModelError("", string.Format("Its not possible to delete the Product nº {0} - {1}",
										id, produto.NomeProduto));
			}
			return View(produto);
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
