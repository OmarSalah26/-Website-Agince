namespace RoleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "password", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
