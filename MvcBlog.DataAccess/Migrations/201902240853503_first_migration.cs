namespace MvcBlog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiketler",
                c => new
                    {
                        EtiketID = c.Int(nullable: false, identity: true),
                        EtiketAdi = c.String(),
                    })
                .PrimaryKey(t => t.EtiketID);
            
            CreateTable(
                "dbo.Makaleler",
                c => new
                    {
                        MakaleID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Icerik = c.String(),
                        YayinTarihi = c.DateTime(nullable: false),
                        KategoriID = c.Int(nullable: false),
                        YazarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MakaleID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID, cascadeDelete: true)
                .ForeignKey("dbo.Yazarlar", t => t.YazarID, cascadeDelete: true)
                .Index(t => t.KategoriID)
                .Index(t => t.YazarID);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Yazarlar",
                c => new
                    {
                        YazarID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Unvan = c.String(),
                        CalistigiKurum = c.String(),
                        Hakkinda = c.String(),
                    })
                .PrimaryKey(t => t.YazarID);
            
            CreateTable(
                "dbo.Yorumlar",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        Icerik = c.String(),
                        YorumTarihi = c.DateTime(nullable: false),
                        UstYorumID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Makale_MakaleID = c.Int(),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Makaleler", t => t.Makale_MakaleID)
                .Index(t => t.UserID)
                .Index(t => t.Makale_MakaleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Resimler",
                c => new
                    {
                        ResimID = c.Int(nullable: false, identity: true),
                        ResimUrl = c.String(),
                        ResimTipID = c.Int(nullable: false),
                        MakaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResimID)
                .ForeignKey("dbo.Makaleler", t => t.MakaleID, cascadeDelete: true)
                .ForeignKey("dbo.ResimTipleri", t => t.ResimTipID, cascadeDelete: true)
                .Index(t => t.ResimTipID)
                .Index(t => t.MakaleID);
            
            CreateTable(
                "dbo.ResimTipleri",
                c => new
                    {
                        ResimTipID = c.Int(nullable: false, identity: true),
                        ResimTipi = c.String(),
                    })
                .PrimaryKey(t => t.ResimTipID);
            
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Makale_MakaleID = c.Int(nullable: false),
                        Etiket_EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_MakaleID, t.Etiket_EtiketID })
                .ForeignKey("dbo.Makaleler", t => t.Makale_MakaleID, cascadeDelete: true)
                .ForeignKey("dbo.Etiketler", t => t.Etiket_EtiketID, cascadeDelete: true)
                .Index(t => t.Makale_MakaleID)
                .Index(t => t.Etiket_EtiketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resimler", "ResimTipID", "dbo.ResimTipleri");
            DropForeignKey("dbo.Resimler", "MakaleID", "dbo.Makaleler");
            DropForeignKey("dbo.Yorumlar", "Makale_MakaleID", "dbo.Makaleler");
            DropForeignKey("dbo.Yorumlar", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Makaleler", "YazarID", "dbo.Yazarlar");
            DropForeignKey("dbo.Makaleler", "KategoriID", "dbo.Kategoriler");
            DropForeignKey("dbo.MakaleEtikets", "Etiket_EtiketID", "dbo.Etiketler");
            DropForeignKey("dbo.MakaleEtikets", "Makale_MakaleID", "dbo.Makaleler");
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_MakaleID" });
            DropIndex("dbo.Resimler", new[] { "MakaleID" });
            DropIndex("dbo.Resimler", new[] { "ResimTipID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Yorumlar", new[] { "Makale_MakaleID" });
            DropIndex("dbo.Yorumlar", new[] { "UserID" });
            DropIndex("dbo.Makaleler", new[] { "YazarID" });
            DropIndex("dbo.Makaleler", new[] { "KategoriID" });
            DropTable("dbo.MakaleEtikets");
            DropTable("dbo.ResimTipleri");
            DropTable("dbo.Resimler");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Yorumlar");
            DropTable("dbo.Yazarlar");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.Makaleler");
            DropTable("dbo.Etiketler");
        }
    }
}
