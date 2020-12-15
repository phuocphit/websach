namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoaDons", "UserName", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.HoaDons", "UserName");
            AddForeignKey("dbo.HoaDons", "UserName", "dbo.Users", "UserName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDons", "UserName", "dbo.Users");
            DropIndex("dbo.HoaDons", new[] { "UserName" });
            DropColumn("dbo.HoaDons", "UserName");
        }
    }
}
