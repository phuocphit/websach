namespace websachs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RoleName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "RoleName", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
