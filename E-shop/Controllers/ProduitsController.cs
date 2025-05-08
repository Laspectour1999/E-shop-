using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_shop.Models;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;


namespace E_shop.Controllers
{
    public class ProduitController : Controller
    {
        eshopContext context = new eshopContext();
        // GET: Produit
        public ActionResult ListeProduit()
        {
            return View("ListeProduit", context.Produit.ToList());
        }

        public ActionResult AfficherProduit(int id)
        {
            Produit P = new Produit();
            P = context.Produit.Find(id);
            if (P != null)
                return View("AfficherProduit", P);
            else return HttpNotFound();

        }

        public ActionResult AjouterProduit()
        {
            Produit p = new Produit();
            return View("AjouterProduit", p);
        }

        [HttpPost]
        public ActionResult AjouterProduit(Produit p ,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    p.produitImageType = image.ContentType;
                    p.produitImage = new byte[image.ContentLength];
                    image.InputStream.Read(p.produitImage, 0, image.ContentLength);
                }
                context.Produit.Add(p);
                context.SaveChanges();
                return RedirectToAction("ListeProduit");
            }
            else return View("AjouterProduit", p);

        }



        public ActionResult ListeSuppression()
        {
            return View("ListeSuppression", context.Produit.ToList());
        }

        public ActionResult Supprimer(int id)
        {
            Produit p = new Produit();
            p = context.Produit.Find(id);
            if (p != null)
                return View("Supprimer", p);
            else return HttpNotFound();
        }

        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerSuppression(int id)
        {
            Produit p = new Produit();
            p = context.Produit.Find(id);
            if (p != null)
            {
                context.Produit.Remove(p);
                context.SaveChanges();
                return RedirectToAction("ListeSuppression");
            }
            else return HttpNotFound();

        }

        public ActionResult ListeModification()
        {
            return View("ListeModification", context.Produit.ToList());

        }

        public ActionResult Modifier(int id)
        {
            Produit p = new Produit();
            p = context.Produit.Find(id);
            if (p != null)
                return View("Modifier", p);
            else return HttpNotFound();
        }

        [HttpPost, ActionName("Modifier")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(Produit p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                    return  View("Modifier", p);
                }
                else return View("ListeProduit", context.Produit.ToList());
            }
            catch
            {

                return View("Modifier", p);

            }
        }

       

    }
}
