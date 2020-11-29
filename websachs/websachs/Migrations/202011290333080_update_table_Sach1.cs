namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_Sach1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sachs", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sachs", "Image");
        }
    }
}
