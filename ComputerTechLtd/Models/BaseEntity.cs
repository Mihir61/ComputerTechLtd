using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Display(Name="Date")]
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }

    }
}