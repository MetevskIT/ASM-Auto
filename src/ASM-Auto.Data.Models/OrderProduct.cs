﻿namespace ASM_Auto.Data.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public int ProductCount { get; set; } = 0;
    }
}
