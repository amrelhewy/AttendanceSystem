namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3_attendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        stud_id = c.Int(nullable: false),
                        AttendDate = c.DateTime(nullable: false),
                        LeaveDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.stud_id, cascadeDelete: true)
                .Index(t => t.stud_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "stud_id", "dbo.Students");
            DropIndex("dbo.Attendances", new[] { "stud_id" });
            DropTable("dbo.Attendances");
        }
    }
}
