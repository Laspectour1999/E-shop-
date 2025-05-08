using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace E_shop.Models
{
    public class eshopInitializer : DropCreateDatabaseIfModelChanges<eshopContext>
    {
        protected override void Seed(eshopContext context)
        {
            base.Seed(context);
            var productList = new List<Produit>
             {
                new Produit
                {
                    NomProduit = "Iphone 15",
                    Quantite = 10,
                    Description = "C'est un iphone 15",
                     Prix = 1100,
                    produitImage=getFileBytes("\\images\\iphone15.jpeg"),
                    produitImageType="image/jpeg"
                },
                new Produit
                {
                    NomProduit = "PC",
                    Quantite = 15,
                    Description = "DELL PC",
                    Prix = 700,
                    produitImage=getFileBytes("\\images\\dellPC.jpeg"),
                    produitImageType="image/jpeg"
                },
                 new Produit
                {
                    NomProduit = "Imprimente",
                    Quantite = 6,
                    Description = "Imprimente DELL",
                    Prix = 1400,
                    produitImage=getFileBytes("\\images\\imprimente.jpeg"),
                    produitImageType="image/jpeg"
                },

             };
            productList.ForEach(p => context.Produit.Add(p));
            context.SaveChanges();
        }

        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }



    }
}