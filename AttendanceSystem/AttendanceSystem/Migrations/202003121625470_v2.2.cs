namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Dep_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Dep_Name", c => c.String());
        }
    }
}
