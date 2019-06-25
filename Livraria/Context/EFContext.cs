using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Livraria.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Loja_Livraria")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Item>().HasRequired(item => item.Livro);
            modelBuilder.Entity<Pedido>().HasRequired(pedido => pedido.Pagamento);
            modelBuilder.Entity<Pedido>().HasRequired(pedido => pedido.Cliente);
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Itens).WithRequired();
            modelBuilder.Entity<Livro>().HasRequired(livro => livro.Categoria);
            modelBuilder.Entity<Livro>().HasRequired(livro => livro.Editora);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


    }
}