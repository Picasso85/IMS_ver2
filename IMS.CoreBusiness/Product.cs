using IMS.CoreBusiness.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 1")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater or equal to 1")]
        public double Price { get; set; }

        [Product_EnsurePriceIsGreaterThanInventoriesCost]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();


        public void AddInventory(Inventory inventory)
        {
            if (!this.ProductInventories.Any(x => x.Inventory != null &&
                x.Inventory.InventoryName.Equals(inventory.InventoryName)))
            {
                this.ProductInventories.Add(new ProductInventory
                {
                    InventoryId = inventory.InventoryId,
                    Inventory = inventory,
                    InventoryQuantity = 1,
                    ProductId = this.ProductId,
                    Product = this
                });
            }
        }
        //components

        //public string Cpu { get; set; }
        //public string Case { get; set; }
        //public string Memory { get; set; }
        //public string SSD { get; set; }
        //public string PowerSupply { get; set; }
        //public string Motherboard { get; set; }
        //public string GraphicCard { get; set; }

    }
}
