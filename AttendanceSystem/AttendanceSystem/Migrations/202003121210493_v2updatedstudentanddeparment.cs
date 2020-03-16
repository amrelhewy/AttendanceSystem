namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2updatedstudentanddeparment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        deptID = c.Int(nullable: false, identity: true),
                        deptName = c.String(),
                    })
                .PrimaryKey(t => t.deptID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        St_Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        deptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.St_Id)
                .ForeignKey("dbo.Departments", t => t.deptID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.deptID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "deptID", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "deptID" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
        }
    }
}
