using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class ItemDAL
    {
        public Item ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Itens.Find(id);
            }
        }

        public IEnumerable<Item> ObterTodos()
        {
            using (var db = new EFContext())
            {
                return db.Itens.ToList();
            }
        }

        public void Adicionar(Item item)
        {
            using (var db = new EFContext())
            {
                db.Itens.Add(item);
                db.SaveChanges();
            }
        }

        public void Editar(Item item)
        {
            using (var db = new EFContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Item item)
        {
            using (var db = new EFContext())
            {
                db.Entry(item).State = EntityState.Deleted;
                db.Itens.Remove(item);
                db.SaveChanges();
            }
        }
    }
}