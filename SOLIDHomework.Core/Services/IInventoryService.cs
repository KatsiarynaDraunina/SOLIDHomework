namespace SOLIDHomework.Core.Services
{
    public interface IInventoryService
    {       
        void ReserveInventory(IShoppingCartService cart);
    }
}
