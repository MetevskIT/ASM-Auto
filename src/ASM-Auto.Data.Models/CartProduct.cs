namespace ASM_Auto.Data.Models
{
    public class CartProduct
    {
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public int ProductCount { get; set; } = 0;
    }
}
