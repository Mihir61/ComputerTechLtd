using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

    }
}