using System.Collections.Generic;

namespace SOLIDHomework.Core.Services
{
    public interface IShoppingCartService
    {
     //   string Country { get; set; }
        IEnumerable<OrderItem> OrderItems { get;}
        void Add(OrderItem orderItem);
        decimal TotalAmount();
    }
}
