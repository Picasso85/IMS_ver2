using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task UpdateInventoryAsync(Inventory inventory);
        Task<Inventory> GetInventoryByIdAsync(int inventoryId);
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
        Task AddInventoryAsync(Inventory inventory);
        //Task<IEnumerable<Inventory>> GetPageByNameAsync(string name, int currentPage);
        //int GetMaxPageCount();
        //int ItemsPerPage { get; }
        

         

        //Task<bool> ExistsAsync (Inventory inventory);
    }
}
