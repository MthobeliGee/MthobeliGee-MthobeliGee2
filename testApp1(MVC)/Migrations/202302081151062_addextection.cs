namespace testApp1_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addextection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Test1", "extection", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Test1", "extection");
        }
    }
}
