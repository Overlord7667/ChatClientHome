namespace ChatClientHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatUsers", "Onlone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatUsers", "Onlone");
        }
    }
}
