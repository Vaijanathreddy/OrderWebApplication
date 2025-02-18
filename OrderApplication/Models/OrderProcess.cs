using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderApplication.Models
{
    public class OrderProcess
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Order amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public string CustomerType { get; set; }

        public decimal Discount { get; set; }
        public decimal FinalTotal { get; set; }
    }
}