using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class dbModel : DbContext
    {
        public DbSet<InstituteInfo> InstituteInfos { get; set; }
    }

    public class InstituteInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }

}