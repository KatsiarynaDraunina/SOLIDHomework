using SOLIDHomework.Core.Exceptions;
using System;

namespace SOLIDHomework.Core.Services
{
    public class InventoryService : IInventoryService
    {
        // that is Database-based service 
        private void Reserve(string identifier, int quantity)
        {
           
        }

        public void ReserveInventory(IShoppingCartService cart)
        {
            foreach (OrderItem item in cart.OrderItems)
            {
                try
                {
                    Reserve(item.Code, item.Amount);
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