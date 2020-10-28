namespace _28_10.Migrations
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
                        Maloaisach = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tenloaisach = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Maloaisach);
            
            CreateTable(
                "dbo.Sachs",
                c => new
                    {
                        Masach = c.String(nullable: false, maxLength: 50, unicode: false),
                        Tensach = c.String(nullable: false, maxLength: 50),
                        Ngayxuatban = c.DateTime(nullable: false),
                        Giasach = c.Int(nullable: false),
                        Matacgia = c.String(nullable: false, maxLength: 50, unicode: false),
                        Maloaisach = c.String(nullable: false, maxLength: 50, unicode: false),
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
