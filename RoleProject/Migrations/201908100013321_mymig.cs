namespace RoleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aginces",
                c => new
                    {
                        Agince_ID = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        phone_number = c.String(),
                        city = c.String(),
                        street = c.String(),
                        photo_Agince = c.String(),
                        userAccount_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Agince_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.userAccount_Id)
                .Index(t => t.userAccount_Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Car_Id = c.String(nullable: false, maxLength: 128),
                        Type_Of_Car = c.String(nullable: false),
                        Car_Brand = c.String(nullable: false),
                        Car_Model = c.String(nullable: false),
                        Chassis_No = c.Int(nullable: false),
                        Start_Book_Date = c.DateTime(),
                        End_Book_Date = c.DateTime(),
                        price_in_day = c.Double(nullable: false),
                        price_Total = c.Double(),
                        Is_reseved = c.Boolean(nullable: false),
                        photo_Car = c.String(),
                        Agince_Of_Car_Agince_ID = c.String(maxLength: 128),
                        CLIENT_Client_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Car_Id)
                .ForeignKey("dbo.Aginces", t => t.Agince_Of_Car_Agince_ID)
                .ForeignKey("dbo.Clients", t => t.CLIENT_Client_ID)
                .Index(t => t.Agince_Of_Car_Agince_ID)
                .Index(t => t.CLIENT_Client_ID);
            
            CreateTable(
                "dbo.Car_properties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        proprity_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Client_ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 100),
                        phone_Number = c.String(nullable: false),
                        age = c.Int(),
                        number_of_licience = c.Int(),
                        date_of_licience_expiry = c.DateTime(),
                    })
                .PrimaryKey(t => t.Client_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Car_propertiesCar",
                c => new
                    {
                        Car_properties_id = c.Int(nullable: false),
                        Car_Car_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Car_properties_id, t.Car_Car_Id })
                .ForeignKey("dbo.Car_properties", t => t.Car_properties_id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Car_Id, cascadeDelete: true)
                .Index(t => t.Car_properties_id)
                .Index(t => t.Car_Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Aginces", "userAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cars", "CLIENT_Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Cars", "Agince_Of_Car_Agince_ID", "dbo.Aginces");
            DropForeignKey("dbo.Car_propertiesCar", "Car_Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Car_propertiesCar", "Car_properties_id", "dbo.Car_properties");
            DropIndex("dbo.Car_propertiesCar", new[] { "Car_Car_Id" });
            DropIndex("dbo.Car_propertiesCar", new[] { "Car_properties_id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cars", new[] { "CLIENT_Client_ID" });
            DropIndex("dbo.Cars", new[] { "Agince_Of_Car_Agince_ID" });
            DropIndex("dbo.Aginces", new[] { "userAccount_Id" });
            DropTable("dbo.Car_propertiesCar");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Clients");
            DropTable("dbo.Car_properties");
            DropTable("dbo.Cars");
            DropTable("dbo.Aginces");
        }
    }
}
