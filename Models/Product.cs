namespace OBJERO.Models
{
    public class Product
    {
        public int ProductId { get; set; }          // Primary Key
        public string Code { get; set; } = string.Empty;   // Unique product code
        public string Name { get; set; } = string.Empty;   // Product name
        public string Description { get; set; } = string.Empty; // Product description
        public decimal Price { get; set; }          // Price with currency precision
    }
}