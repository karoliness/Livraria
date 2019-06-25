using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string DataDoPedido { get; set; }
        public string DataDoPagamento { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string EnderecoDeEntrega { get; set; }
        public double Frete { get; set; }
        public virtual ICollection<Item> Itens { get; set; }

    }
}