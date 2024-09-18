﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindMVC.Data
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Productid { get; set; }
        public string Productname { get; set; }
        public int? Supplierid { get; set; }
        public int? Categoryid { get; set; }
        public string Quantityperunit { get; set; }
        public decimal? Unitprice { get; set; }
        public short? Unitsinstock { get; set; }
        public short? Unitsonorder { get; set; }
        public short? Reorderlevel { get; set; }
        public byte Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
