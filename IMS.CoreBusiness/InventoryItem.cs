using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public string InventoryName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 1")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater or equal to 1")]
        public double Price { get; set; }
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
    }
}