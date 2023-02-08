namespace testApp1_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Test1", "dateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Test1", "excelFile", c => c.String());
            DropColumn("dbo.Test1", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Test1", "age", c => c.Int(nullable: false));
            DropColumn("dbo.Test1", "excelFile");
            DropColumn("dbo.Test1", "dateOfBirth");
        }
    }
}
