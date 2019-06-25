using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class PedidoDAL
    {
        public Pedido ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Pedidos.Find(id);
            }
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            using (var db = new EFContext())
            {
                return db.Pedidos.ToList();
            }
        }

        public void Adicionar(Pedido pedido)
        {
            using (var db = new EFContext())
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
            }
        }

        public void Editar(Pedido pedido)
        {
            using (var db = new EFContext())
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Pedido pedido)
        {
            using (var db = new EFContext())
            {
                db.Entry(pedido).State = EntityState.Deleted;
                db.Pedidos.Remove(pedido);
                db.SaveChanges();
            }
        }
    }
}