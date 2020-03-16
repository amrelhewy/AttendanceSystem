namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v322 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Attendances", "AttendDay");
            DropColumn("dbo.Attendances", "LeaveDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "LeaveDay", c => c.DateTime());
            AddColumn("dbo.Attendances", "AttendDay", c => c.DateTime(nullable: false));
        }
    }
}
