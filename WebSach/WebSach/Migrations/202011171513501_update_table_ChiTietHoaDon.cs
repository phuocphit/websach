namespace WebSach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_ChiTietHoaDon : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            DropPrimaryKey("dbo.ChiTietHoaDons");
            AddColumn("dbo.ChiTietHoaDons", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ChiTietHoaDons", "MaHoaDon", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.ChiTietHoaDons", "id");
            CreateIndex("dbo.ChiTietHoaDons", "MaHoaDon");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            DropPrimaryKey("dbo.ChiTietHoaDons");
            AlterColumn("dbo.ChiTietHoaDons", "MaHoaDon", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ChiTietHoaDons", "id");
            AddPrimaryKey("dbo.ChiTietHoaDons", "MaHoaDon");
            CreateIndex("dbo.ChiTietHoaDons", "MaHoaDon");
        }
    }
}
