namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Attendances", new[] { "stud_id" });
            CreateIndex("dbo.Attendances", "stud_id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Attendances", new[] { "stud_id" });
            CreateIndex("dbo.Attendances", "stud_id");
        }
    }
}
