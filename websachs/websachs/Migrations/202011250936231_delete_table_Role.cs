namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_table_Role : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            AddColumn("dbo.Users", "RoleName", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "RoleID");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 50, unicode: false),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Users", "RoleID", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Users", "RoleName");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "RoleID");
        }
    }
}
