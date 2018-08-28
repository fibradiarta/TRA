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
                        TRAVEL_travel_id = c.Int(),
                    })
                .PrimaryKey(t => t.catagory_id)
                .ForeignKey("dbo.TRAVELs", t => t.TRAVEL_travel_id)
                .Index(t => t.TRAVEL_travel_id);
            
            CreateTable(
                "dbo.DEPARTMENTs",
                c => new
                    {
                        department_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        USER_user_id = c.Int(),
                    })
                .PrimaryKey(t => t.department_id)
                .ForeignKey("dbo.USERs", t => t.USER_user_id)
                .Index(t => t.USER_user_id);
            
            CreateTable(
                "dbo.HISTORies",
                c => new
                    {
                        history_id = c.Int(nullable: false, identity: true),
                        travel_id = c.Int(nullable: false),
                        status = c.String(),
                        date_approval = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.history_id);
            
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
                        HISTORY_history_id = c.Int(),
                        HOTEL_COST_hotel_id = c.Int(),
                        TRANSPORT_COST_transport_id = c.Int(),
                    })
                .PrimaryKey(t => t.travel_id)
                .ForeignKey("dbo.HISTORies", t => t.HISTORY_history_id)
                .ForeignKey("dbo.HOTEL_COST", t => t.HOTEL_COST_hotel_id)
                .ForeignKey("dbo.TRANSPORT_COST", t => t.TRANSPORT_COST_transport_id)
                .Index(t => t.HISTORY_history_id)
                .Index(t => t.HOTEL_COST_hotel_id)
                .Index(t => t.TRANSPORT_COST_transport_id);
            
            CreateTable(
                "dbo.USERs",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        department_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                        name = c.String(),
                        email = c.String(),
                        job_title = c.String(),
                        gender = c.String(),
                        birth_date = c.DateTime(nullable: false),
                        password = c.String(),
                        TRAVEL_travel_id = c.Int(),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.TRAVELs", t => t.TRAVEL_travel_id)
                .Index(t => t.TRAVEL_travel_id);
            
            CreateTable(
                "dbo.ROLEs",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        USER_user_id = c.Int(),
                    })
                .PrimaryKey(t => t.role_id)
                .ForeignKey("dbo.USERs", t => t.USER_user_id)
                .Index(t => t.USER_user_id);
            
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
                .PrimaryKey(t => t.hotel_id);
            
            CreateTable(
                "dbo.TYPEs",
                c => new
                    {
                        type_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        TRANSPORT_COST_transport_id = c.Int(),
                    })
                .PrimaryKey(t => t.type_id)
                .ForeignKey("dbo.TRANSPORT_COST", t => t.TRANSPORT_COST_transport_id)
                .Index(t => t.TRANSPORT_COST_transport_id);
            
            CreateTable(
                "dbo.TRANSPORT_COST",
                c => new
                    {
                        transport_id = c.Int(nullable: false, identity: true),
                        type_id = c.Int(nullable: false),
                        travel_id = c.Int(nullable: false),
                        attachment = c.String(),
                        cost = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.transport_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TYPEs", "TRANSPORT_COST_transport_id", "dbo.TRANSPORT_COST");
            DropForeignKey("dbo.TRAVELs", "TRANSPORT_COST_transport_id", "dbo.TRANSPORT_COST");
            DropForeignKey("dbo.TRAVELs", "HOTEL_COST_hotel_id", "dbo.HOTEL_COST");
            DropForeignKey("dbo.TRAVELs", "HISTORY_history_id", "dbo.HISTORies");
            DropForeignKey("dbo.USERs", "TRAVEL_travel_id", "dbo.TRAVELs");
            DropForeignKey("dbo.ROLEs", "USER_user_id", "dbo.USERs");
            DropForeignKey("dbo.DEPARTMENTs", "USER_user_id", "dbo.USERs");
            DropForeignKey("dbo.CATEGORies", "TRAVEL_travel_id", "dbo.TRAVELs");
            DropIndex("dbo.TYPEs", new[] { "TRANSPORT_COST_transport_id" });
            DropIndex("dbo.ROLEs", new[] { "USER_user_id" });
            DropIndex("dbo.USERs", new[] { "TRAVEL_travel_id" });
            DropIndex("dbo.TRAVELs", new[] { "TRANSPORT_COST_transport_id" });
            DropIndex("dbo.TRAVELs", new[] { "HOTEL_COST_hotel_id" });
            DropIndex("dbo.TRAVELs", new[] { "HISTORY_history_id" });
            DropIndex("dbo.DEPARTMENTs", new[] { "USER_user_id" });
            DropIndex("dbo.CATEGORies", new[] { "TRAVEL_travel_id" });
            DropTable("dbo.TRANSPORT_COST");
            DropTable("dbo.TYPEs");
            DropTable("dbo.HOTEL_COST");
            DropTable("dbo.ROLEs");
            DropTable("dbo.USERs");
            DropTable("dbo.TRAVELs");
            DropTable("dbo.HISTORies");
            DropTable("dbo.DEPARTMENTs");
            DropTable("dbo.CATEGORies");
        }
    }
}
