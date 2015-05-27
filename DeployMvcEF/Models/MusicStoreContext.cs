using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeployMvcEF.Models
{
    public class MusicStoreContext: DbContext
    {
        public DbSet<Artist> artists { get; set; }
    }
}