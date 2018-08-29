namespace Bootcamp18_TRA_Codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CATEGORies",
                c => new
                    {
                        catagory_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.catagory_id);
            
            CreateTable(
                "dbo.TRAVELs",
                c => new
                    {
                        travel_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        departure_date = c.DateTime(nullable: false),
                        arrival_date = c.DateTime(nullable: false),
                        destination = c.String(),
                        status = c.String(),
                        total = c.Int(nullable: false),
                        Categories_catagory_id = c.Int(),
                    })
                .PrimaryKey(t => t.travel_id)
                .ForeignKey("dbo.CATEGORies", t => t.Categories_catagory_id)
                .ForeignKey("dbo.USERs", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.Categories_catagory_id);
            
            CreateTable(
                "dbo.HISTORies",
                c => new
                    {
                        history_id = c.Int(nullable: false, identity: true),
                        travel_id = c.Int(nullable: false),
                        status = c.String(),
                        date_approval = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.history_id)
                .ForeignKey("dbo.TRAVELs", t => t.travel_id, cascadeDelete: true)
                .Index(t => t.travel_id);
            
            CreateTable(
                "dbo.HOTEL_COST",
                c => new
                    {
                        hotel_id = c.Int(nullable: false, identity: true),
                        travel_id = c.Int(nullable: false),
                        name = c.String(),
                        cost = c.Int(nullable: false),
                        attachment = c.String(),
                        date_checkin = c.DateTime(nullable: false),
                        date_checkout = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.hotel_id)
                .ForeignKey("dbo.TRAVELs", t => t.travel_id, cascadeDelete: true)
                .Index(t => t.travel_id);
            
            CreateTable(
                "dbo.TRANSPORT_COST",
                c => new
                    {
                        transport_id = c.Int(nullable: false, identity: true),
                        attachment = c.String(),
                        cost = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        type_id = c.Int(nullable: false),
                        travel_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.transport_id)
                .ForeignKey("dbo.TRAVELs", t => t.travel_id, cascadeDelete: true)
                .ForeignKey("dbo.TYPEs", t => t.type_id, cascadeDelete: true)
                .Index(t => t.type_id)
                .Index(t => t.travel_id);
            
            CreateTable(
                "dbo.TYPEs",
                c => new
                    {
                        type_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.type_id);
            
            CreateTable(
                "dbo.USERs",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        job_title = c.String(),
                        gender = c.String(),
                        birth_date = c.DateTime(nullable: false),
                        password = c.String(),
                        department_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.DEPARTMENTs", t => t.department_id, cascadeDelete: true)
                .ForeignKey("dbo.ROLEs", t => t.role_id, cascadeDelete: true)
                .Index(t => t.department_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.DEPARTMENTs",
                c => new
                    {
                        department_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.department_id);
            
            CreateTable(
                "dbo.ROLEs",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.role_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TRAVELs", "user_id", "dbo.USERs");
            DropForeignKey("dbo.USERs", "role_id", "dbo.ROLEs");
            DropForeignKey("dbo.USERs", "department_id", "dbo.DEPARTMENTs");
            DropForeignKey("dbo.TRANSPORT_COST", "type_id", "dbo.TYPEs");
            DropForeignKey("dbo.TRANSPORT_COST", "travel_id", "dbo.TRAVELs");
            DropForeignKey("dbo.HOTEL_COST", "travel_id", "dbo.TRAVELs");
            DropForeignKey("dbo.HISTORies", "travel_id", "dbo.TRAVELs");
            DropForeignKey("dbo.TRAVELs", "Categories_catagory_id", "dbo.CATEGORies");
            DropIndex("dbo.USERs", new[] { "role_id" });
            DropIndex("dbo.USERs", new[] { "department_id" });
            DropIndex("dbo.TRANSPORT_COST", new[] { "travel_id" });
            DropIndex("dbo.TRANSPORT_COST", new[] { "type_id" });
            DropIndex("dbo.HOTEL_COST", new[] { "travel_id" });
            DropIndex("dbo.HISTORies", new[] { "travel_id" });
            DropIndex("dbo.TRAVELs", new[] { "Categories_catagory_id" });
            DropIndex("dbo.TRAVELs", new[] { "user_id" });
            DropTable("dbo.ROLEs");
            DropTable("dbo.DEPARTMENTs");
            DropTable("dbo.USERs");
            DropTable("dbo.TYPEs");
            DropTable("dbo.TRANSPORT_COST");
            DropTable("dbo.HOTEL_COST");
            DropTable("dbo.HISTORies");
            DropTable("dbo.TRAVELs");
            DropTable("dbo.CATEGORies");
        }
    }
}
