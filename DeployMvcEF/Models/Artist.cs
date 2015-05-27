using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeployMvcEF.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Required()]
        [StringLength(100,MinimumLength=2)]
        public string Name { get; set; }

        //for optimistic concurrency check
        //[Timestamp()]
        //public byte[] RowVersion { get; set; }


        //have to set the update() method as virtual and override it in the artistRepository
        [ConcurrencyCheck()]
        public int Version { get; set; }
    }
}