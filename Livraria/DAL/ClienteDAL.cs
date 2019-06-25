using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class ClienteDAL
    {
        public Cliente ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Clientes.Find(id);
            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            using(var db = new EFContext())
            {
                return db.Clientes.ToList();
            }
        }

        public void Adicionar (Cliente cliente)
        {
            using(var db = new EFContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }

        public void Editar (Cliente cliente)
        {
            using(var db = new EFContext())
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir (Cliente cliente)
        {
            using(var db = new EFContext())
            {
                db.Entry(cliente).State = EntityState.Deleted;
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }
    }
}