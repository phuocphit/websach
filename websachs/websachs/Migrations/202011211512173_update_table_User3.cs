namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_User3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "PassWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PassWord", c => c.String(maxLength: 50));
        }
    }
}
