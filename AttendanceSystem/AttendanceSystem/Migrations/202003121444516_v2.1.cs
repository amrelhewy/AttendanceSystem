namespace AttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Dep_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Dep_Name");
        }
    }
}
