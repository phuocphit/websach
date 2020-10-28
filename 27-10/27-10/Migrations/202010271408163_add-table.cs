namespace _27_10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiSachs",
                c => new
                    {
                        Maloaisach = c.String(nullable: false, identity: true),
                        Tenloaisach = c.String(),
                    })
                .PrimaryKey(t => t.Maloaisach);
            
            CreateTable(
                "dbo.Sachs",
                c => new
                    {
                        Masach = c.String(nullable: false, identity: true),
                        Tensach = c.String(),
                        Ngayxuatban = c.DateTime(),
                        Giasach = c.Int(),
                        Matacgia = c.String(),
                        Maloaisach = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Masach)
                .ForeignKey("dbo.LoaiSachs", t => t.Maloaisach, cascadeDelete: true)
                .Index(t => t.Maloaisach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sachs", "Maloaisach", "dbo.LoaiSachs");
            DropIndex("dbo.Sachs", new[] { "Maloaisach" });
            DropTable("dbo.Sachs");
            DropTable("dbo.LoaiSachs");
        }
    }
}
