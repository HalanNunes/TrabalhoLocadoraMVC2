namespace TrabalhoLocadoraMVC2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrabalhoLocadoraMVC2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrabalhoLocadoraMVC2.Models.Repository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrabalhoLocadoraMVC2.Models.Repository context)
        {
            context.TipoCopias.AddOrUpdate(
                p => p.Descricao,
                new TipoCopia { Descricao = "CDRom" },
                new TipoCopia { Descricao = "DVD" },
                new TipoCopia { Descricao = "Blue Ray" },
                new TipoCopia { Descricao = "VHS" }
                );
        }
    }
}
