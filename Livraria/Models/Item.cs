using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Item
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Desconto { get; set; }
        public virtual Livro Livro { get; set; }

    }
}