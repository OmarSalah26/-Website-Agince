namespace RoleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "city", c => c.String());
            AddColumn("dbo.Clients", "street", c => c.String());
            AddColumn("dbo.AspNetUsers", "city", c => c.String());
            AddColumn("dbo.AspNetUsers", "street", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "street");
            DropColumn("dbo.AspNetUsers", "city");
            DropColumn("dbo.Clients", "street");
            DropColumn("dbo.Clients", "city");
        }
    }
}
