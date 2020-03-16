namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
