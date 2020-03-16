namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "LeaveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "LeaveDate", c => c.DateTime(nullable: false));
        }
    }
}
