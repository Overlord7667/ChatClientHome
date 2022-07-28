namespace ChatClientHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Mail");
        }
    }
}
