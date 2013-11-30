namespace TrabalhoLocadoraMVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocacoesToCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TituloAtors", "Titulo_Id", "dbo.Tituloes");
            DropForeignKey("dbo.TituloAtors", "Ator_Id", "dbo.Ators");
            DropIndex("dbo.TituloAtors", new[] { "Titulo_Id" });
            DropIndex("dbo.TituloAtors", new[] { "Ator_Id" });
            CreateTable(
                "dbo.AtorTituloes",
                c => new
                    {
                        Ator_Id = c.Int(nullable: false),
                        Titulo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ator_Id, t.Titulo_Id })
                .ForeignKey("dbo.Ators", t => t.Ator_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tituloes", t => t.Titulo_Id, cascadeDelete: true)
                .Index(t => t.Ator_Id)
                .Index(t => t.Titulo_Id);
            
            DropTable("dbo.TituloAtors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TituloAtors",
                c => new
                    {
                        Titulo_Id = c.Int(nullable: false),
                        Ator_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Titulo_Id, t.Ator_Id });
            
            DropIndex("dbo.AtorTituloes", new[] { "Titulo_Id" });
            DropIndex("dbo.AtorTituloes", new[] { "Ator_Id" });
            DropForeignKey("dbo.AtorTituloes", "Titulo_Id", "dbo.Tituloes");
            DropForeignKey("dbo.AtorTituloes", "Ator_Id", "dbo.Ators");
            DropTable("dbo.AtorTituloes");
            CreateIndex("dbo.TituloAtors", "Ator_Id");
            CreateIndex("dbo.TituloAtors", "Titulo_Id");
            AddForeignKey("dbo.TituloAtors", "Ator_Id", "dbo.Ators", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TituloAtors", "Titulo_Id", "dbo.Tituloes", "Id", cascadeDelete: true);
        }
    }
}
