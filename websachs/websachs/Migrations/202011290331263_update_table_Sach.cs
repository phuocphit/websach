namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_Sach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sachs", "UrlImage", c => c.String());
            DropColumn("dbo.Sachs", "SoTrang");
            DropColumn("dbo.Sachs", "images");
            DropColumn("dbo.Sachs", "NoiDung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sachs", "NoiDung", c => c.String());
            AddColumn("dbo.Sachs", "images", c => c.String());
            AddColumn("dbo.Sachs", "SoTrang", c => c.Int(nullable: false));
            DropColumn("dbo.Sachs", "UrlImage");
        }
    }
}
