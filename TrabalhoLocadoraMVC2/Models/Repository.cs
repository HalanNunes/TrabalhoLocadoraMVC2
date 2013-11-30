using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrabalhoLocadoraMVC2.Models
{
    public class Repository : DbContext
    {
        public Repository() : base("DefaultConnection") { }

        public DbSet<Cliente> Clientes { set; get; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TipoTitulo> TipoTitulos { get; set; }
        public DbSet<Copia> Copias { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<TipoCopia> TipoCopias { get; set; }
    }
}