using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Categoria Categoria { get; set; }
        public Editora Editora { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int Pagina { get; set; }
        public int Ano { get; set; }
        public int Edicao { get; set; }

    }
}