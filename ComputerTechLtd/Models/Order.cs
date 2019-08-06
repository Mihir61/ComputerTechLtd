using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
    }
}