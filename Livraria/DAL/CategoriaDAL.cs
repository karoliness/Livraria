using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class CategoriaDAL
    {
        public Categoria ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Categorias.Find(id);
            }
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            using (var db = new EFContext())
            {
                return db.Categorias.ToList();
            }
        }

        public void Adicionar(Categoria categoria)
        {
            using (var db = new EFContext())
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
            }
        }

        public void Editar(Categoria categoria)
        {
            using (var db = new EFContext())
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Categoria categoria)
        {
            using (var db = new EFContext())
            {
                db.Entry(categoria).State = EntityState.Deleted;
                db.Categorias.Remove(categoria);
                db.SaveChanges();
            }
        }
    }
}