namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_User1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PassWord", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PassWord", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
