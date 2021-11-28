namespace WebApplication1.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.dbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.dbModel context)
        {
            dbModel db = new dbModel();
            List<InstituteInfo> institutes = new List<InstituteInfo>
            {
                 new InstituteInfo{ ContactName="Tamim", Email="t@t.com", Location="Dhaka",
                     MobileNo="01741548454", Name="BUBT"},
                    new InstituteInfo{ ContactName="Hamim", Email="t@t.com", Location="Dhaka",
                     MobileNo="01741548454", Name="IDEAL"},
                     new InstituteInfo{ ContactName="POlash", Email="t@t.com", Location="Dhaka",
                     MobileNo="01741548454", Name="Green University"},
                      new InstituteInfo{ ContactName="Kamal", Email="t@t.com", Location="Dhaka",
                     MobileNo="01741548454", Name="World University"}
            };

            db.InstituteInfos.AddRange(institutes);
            db.SaveChanges();
        }
    }
}
