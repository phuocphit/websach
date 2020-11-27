namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_User4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PassWord", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PassWord");
        }
    }
}
