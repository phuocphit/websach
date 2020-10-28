namespace LTQL23_10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loaisaches",
                c => new
                    {
                        Maloaisach = c.Int(nullable: false, identity: true),
                        Maloaisach_id = c.Int(nullable: false),
                        Tenloaisach = c.String(),
                    })
                .PrimaryKey(t => t.Maloaisach)
                .ForeignKey("dbo.Saches", t => t.Maloaisach_id, cascadeDelete: true)
                .Index(t => t.Maloaisach_id);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        Masach = c.Int(nullable: false, identity: true),
                        Tensach = c.String(),
                        Ngayxuatban = c.String(),
                        Giasach = c.String(),
                        Matacgia = c.String(),
                    })
                .PrimaryKey(t => t.Masach);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loaisaches", "Maloaisach_id", "dbo.Saches");
            DropIndex("dbo.Loaisaches", new[] { "Maloaisach_id" });
            DropTable("dbo.Saches");
            DropTable("dbo.Loaisaches");
        }
    }
}
