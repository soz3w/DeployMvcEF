using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeployMvcEF.Models.Repositories
{
    public class ArtistRepository:Repository<Artist>
    {
        // i can add more methods
        public List<Artist> getByName(string name)
        {
           return  DbSet.Where(a => a.Name.Contains(name)).ToList();
        }
        /// <summary>
        /// method created for the checkConcurrency
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Artist entity)
        {

            base.Update(entity);
            SaveChanges();
            entity.Version++;
            base.Update(entity);
            SaveChanges();
        }
    }
}