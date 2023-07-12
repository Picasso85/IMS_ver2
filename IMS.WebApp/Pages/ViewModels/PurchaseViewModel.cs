using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.Pages.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PONumber { get; set; } = string.Empty;
        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage ="You have to select an inventory")]
        public int InventoryId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than 1")]
        public int QuantityToPurchase { get; set; }
        [Required]
        public double InventoryPrice { get; set; }

    }
}
