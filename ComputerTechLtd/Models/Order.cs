using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComputerTechLtd.Models
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }
        [Display(Name="Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}