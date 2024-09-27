using SOLIDHomework.Core.Exceptions;
using System;

namespace SOLIDHomework.Core.Services
{
    // Move inventory logic to the Inventory Service
    public class Inventory: IInventory
    {
        IInventoryService _inventoryService;

        public Inventory(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void ReserveInventory(IShoppingCartService cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    _inventoryService.Reserve(item.Code, item.Amount);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Code, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }
    }
}
