namespace ChatClientHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Login : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChatUsers", "Login", c => c.String());
            AlterColumn("dbo.ChatUsers", "Pass", c => c.String());
            AlterColumn("dbo.ChatUsers", "Name", c => c.String());
            AlterColumn("dbo.ChatUsers", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChatUsers", "Mail", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatUsers", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatUsers", "Pass", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatUsers", "Login", c => c.Int(nullable: false));
        }
    }
}
