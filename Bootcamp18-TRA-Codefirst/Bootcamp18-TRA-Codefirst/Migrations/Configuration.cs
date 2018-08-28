namespace Bootcamp18_TRA_Codefirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bootcamp18_TRA_Codefirst.Models.baseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Bootcamp18_TRA_Codefirst.Models.baseContext";
        }

        protected override void Seed(Bootcamp18_TRA_Codefirst.Models.baseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
