namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDons", "User_UserName", "dbo.Users");
            DropForeignKey("dbo.HoaDons", "User_UserName1", "dbo.Users");
            DropForeignKey("dbo.HoaDons", "UserName", "dbo.Users");
            DropIndex("dbo.HoaDons", new[] { "UserName" });
            DropIndex("dbo.HoaDons", new[] { "User_UserName" });
            DropIndex("dbo.HoaDons", new[] { "User_UserName1" });
            DropColumn("dbo.HoaDons", "UserName");
            DropColumn("dbo.HoaDons", "User_UserName");
            DropColumn("dbo.HoaDons", "User_UserName1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HoaDons", "User_UserName1", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.HoaDons", "User_UserName", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.HoaDons", "UserName", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.HoaDons", "User_UserName1");
            CreateIndex("dbo.HoaDons", "User_UserName");
            CreateIndex("dbo.HoaDons", "UserName");
            AddForeignKey("dbo.HoaDons", "UserName", "dbo.Users", "UserName");
            AddForeignKey("dbo.HoaDons", "User_UserName1", "dbo.Users", "UserName");
            AddForeignKey("dbo.HoaDons", "User_UserName", "dbo.Users", "UserName");
        }
    }
}
