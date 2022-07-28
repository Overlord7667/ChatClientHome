namespace ChatClientHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.Int(nullable: false),
                        Pass = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        Mail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChatUsers");
        }
    }
}
