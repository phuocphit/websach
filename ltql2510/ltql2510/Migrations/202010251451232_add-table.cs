namespace ltql2510.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiSaches",
                c => new
                    {
                        Maloaisach = c.Int(nullable: false, identity: true),
                        Tenloaisach = c.String(),
                    })
                .PrimaryKey(t => t.Maloaisach);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        Masach = c.Int(nullable: false, identity: true),
                        Tensach = c.String(),
                        Ngayxuatban = c.String(),
                        Giasach = c.String(),
                        Matacgia = c.String(),
                        Maloaisach = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Masach)
                .ForeignKey("dbo.LoaiSaches", t => t.Maloaisach, cascadeDelete: true)
                .Index(t => t.Maloaisach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "Maloaisach", "dbo.LoaiSaches");
            DropIndex("dbo.Saches", new[] { "Maloaisach" });
            DropTable("dbo.Saches");
            DropTable("dbo.LoaiSaches");
        }
    }
}
