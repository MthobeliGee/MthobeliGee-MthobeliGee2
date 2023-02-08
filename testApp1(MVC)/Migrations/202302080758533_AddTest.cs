namespace testApp1_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Test1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Test1");
        }
    }
}
