using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public int ItemsPerPage { get; private set; } = 10;
        
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                
            };

        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = _inventories.First(x => x.InventoryId == inventoryId);
            var newInv = new Inventory
            {
                InventoryId = inv.InventoryId,
                InventoryName = inv.InventoryName,
                Price = inv.Price,
                Quantity = inv.Quantity
            };

            return await Task.FromResult(newInv);
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetPageByNameAsync(string name, int page = 0)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                var paginatedInventories = _inventories
                    .Skip((page) * ItemsPerPage)
                    .Take(ItemsPerPage);

                return await Task.FromResult(paginatedInventories);
            }
            else
            {
                var paginatedInventories = _inventories
                    .Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .Skip((page) * ItemsPerPage)
                    .Take(ItemsPerPage);

                return await Task.FromResult(paginatedInventories);
            }
        }

        public int GetMaxPageCount()
        {
            return _inventories.Count / ItemsPerPage;
        }

        public class Pagination
        {
            public int ItemsPerPage { get; private set; } = 10;

            public void SetItemsPerPage(int value)
            {
                ItemsPerPage = value;
            }
        }

        //public int getmaxpagecount(string searchquery = "")
        //{
        //    int maxpages = getmaxpagecount();
        //    if (string.isnullorwhitespace(searchquery))
        //    {
        //        return _inventories.count / itemsperpage;
        //    }
        //    else
        //    {
        //        int matchingitemcount = _inventories.count(inventory => inventory.contains(searchquery));
        //        return matchingitemcount / itemsperpage;
        //    }
        //}
    }
}