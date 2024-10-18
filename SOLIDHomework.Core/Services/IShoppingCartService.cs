using System.Collections.Generic;

namespace SOLIDHomework.Core.Services
{
    public interface IShoppingCartService
    {           
        IEnumerable<OrderItem> OrderItems { get;}
        void Add(OrderItem orderItem);
        decimal TotalAmount();        
    }
}
