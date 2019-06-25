using Livraria.Context;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.DAL
{
    public class LivroDAL
    {
        public Livro ObterPor(int id)
        {
            using (var db = new EFContext())
            {
                return db.Livros.Find(id);
            }
        }

        public IEnumerable<Livro> ObterTodos()
        {
            using (var db = new EFContext())
            {
                return db.Livros.ToList();
            }
        }

        public void Adicionar(Livro livro)
        {
            using (var db = new EFContext())
            {
                db.Livros.Add(livro);
                db.SaveChanges();
            }
        }

        public void Editar(Livro livro)
        {
            using (var db = new EFContext())
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Excluir(Livro livro)
        {
            using (var db = new EFContext())
            {
                db.Entry(livro).State = EntityState.Deleted;
                db.Livros.Remove(livro);
                db.SaveChanges();
            }
        }
    }
}