using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_shop.Models
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un nom")]

        public string NomProduit { get; set; }

        public int Quantite { get; set; }
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }
        public int Prix { get; set; }
        public byte[] produitImage { get; set; }

        public string produitImageType { get; set; }



    }
}