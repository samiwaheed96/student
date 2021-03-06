﻿using System;
using System.Collections.Generic;

namespace eshop.Models
{
    public partial class SystemItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public decimal? CostPice { get; set; }
        public decimal? SalePrice { get; set; }
        public string MainImage { get; set; }
        public string ItemCode { get; set; }
        public string Status { get; set; }
        public int? ItemCategory { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
