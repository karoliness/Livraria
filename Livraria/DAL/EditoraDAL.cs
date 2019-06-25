using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class EditoraDAL
    {
        public Editora ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Editoras.Find(id);
            }
        }

        public IEnumerable<Editora> ObterTodos()
        {
            using (var db = new EFContext())
            {
                return db.Editoras.ToList();
            }
        }

        public void Adicionar(Editora editora)
        {
            using (var db = new EFContext())
            {
                db.Editoras.Add(editora);
                db.SaveChanges();
            }
        }

        public void Editar(Editora editora)
        {
            using (var db = new EFContext())
            {
                db.Entry(editora).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Editora editora)
        {
            using (var db = new EFContext())
            {
                db.Entry(editora).State = EntityState.Deleted;
                db.Editoras.Remove(editora);
                db.SaveChanges();
            }
        }
    }
}