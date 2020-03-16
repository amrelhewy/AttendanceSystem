namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3_late_bool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Late", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "Late");
        }
    }
}
