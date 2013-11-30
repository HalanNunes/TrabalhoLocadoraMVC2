namespace TrabalhoLocadoraMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Nascimento = c.DateTime(nullable: false),
                        Endereco = c.String(maxLength: 200),
                        NumeroEndereco = c.Int(nullable: false),
                        Bairro = c.String(maxLength: 50),
                        Complemento = c.String(maxLength: 50),
                        Cidade = c.String(maxLength: 50),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Ators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tituloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sinopse = c.String(nullable: false),
                        OrigemTitulo = c.String(nullable: false, maxLength: 100),
                        Ano = c.Short(nullable: false),
                        TipoTituloId = c.Int(nullable: false),
                        TipoTitulo_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoTituloes", t => t.TipoTitulo_Id)
                .Index(t => t.TipoTitulo_Id);
            
            CreateTable(
                "dbo.TipoTituloes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Copias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TituloId = c.Int(nullable: false),
                        TipoCopiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tituloes", t => t.TituloId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCopias", t => t.TipoCopiaId, cascadeDelete: true)
                .Index(t => t.TituloId)
                .Index(t => t.TipoCopiaId);
            
            CreateTable(
                "dbo.TipoCopias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        CopiaId = c.Int(nullable: false),
                        DataLocacao = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(),
                        Copia_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Copias", t => t.Copia_Id)
                .Index(t => t.ClienteId)
                .Index(t => t.Copia_Id);
            
            CreateTable(
                "dbo.GeneroTituloes",
                c => new
                    {
                        Genero_Id = c.Long(nullable: false),
                        Titulo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genero_Id, t.Titulo_Id })
                .ForeignKey("dbo.Generoes", t => t.Genero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tituloes", t => t.Titulo_Id, cascadeDelete: true)
                .Index(t => t.Genero_Id)
                .Index(t => t.Titulo_Id);
            
            CreateTable(
                "dbo.TituloAtors",
                c => new
                    {
                        Titulo_Id = c.Int(nullable: false),
                        Ator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Titulo_Id, t.Ator_Id })
                .ForeignKey("dbo.Tituloes", t => t.Titulo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ators", t => t.Ator_Id, cascadeDelete: true)
                .Index(t => t.Titulo_Id)
                .Index(t => t.Ator_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TituloAtors", new[] { "Ator_Id" });
            DropIndex("dbo.TituloAtors", new[] { "Titulo_Id" });
            DropIndex("dbo.GeneroTituloes", new[] { "Titulo_Id" });
            DropIndex("dbo.GeneroTituloes", new[] { "Genero_Id" });
            DropIndex("dbo.Locacaos", new[] { "Copia_Id" });
            DropIndex("dbo.Locacaos", new[] { "ClienteId" });
            DropIndex("dbo.Copias", new[] { "TipoCopiaId" });
            DropIndex("dbo.Copias", new[] { "TituloId" });
            DropIndex("dbo.Tituloes", new[] { "TipoTitulo_Id" });
            DropForeignKey("dbo.TituloAtors", "Ator_Id", "dbo.Ators");
            DropForeignKey("dbo.TituloAtors", "Titulo_Id", "dbo.Tituloes");
            DropForeignKey("dbo.GeneroTituloes", "Titulo_Id", "dbo.Tituloes");
            DropForeignKey("dbo.GeneroTituloes", "Genero_Id", "dbo.Generoes");
            DropForeignKey("dbo.Locacaos", "Copia_Id", "dbo.Copias");
            DropForeignKey("dbo.Locacaos", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Copias", "TipoCopiaId", "dbo.TipoCopias");
            DropForeignKey("dbo.Copias", "TituloId", "dbo.Tituloes");
            DropForeignKey("dbo.Tituloes", "TipoTitulo_Id", "dbo.TipoTituloes");
            DropTable("dbo.TituloAtors");
            DropTable("dbo.GeneroTituloes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.TipoCopias");
            DropTable("dbo.Copias");
            DropTable("dbo.Generoes");
            DropTable("dbo.TipoTituloes");
            DropTable("dbo.Tituloes");
            DropTable("dbo.Ators");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Clientes");
        }
    }
}
