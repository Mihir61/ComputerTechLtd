using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }

    }
}