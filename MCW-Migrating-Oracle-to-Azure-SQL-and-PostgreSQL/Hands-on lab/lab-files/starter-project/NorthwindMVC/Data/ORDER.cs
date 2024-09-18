﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindMVC.Data
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Orderid { get; set; }
        public string Customerid { get; set; }
        public decimal? Employeeid { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public int? Shipvia { get; set; }
        public decimal? Freight { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipregion { get; set; }
        public string Shippostalcode { get; set; }
        public string Shipcountry { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper ShipviaNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
