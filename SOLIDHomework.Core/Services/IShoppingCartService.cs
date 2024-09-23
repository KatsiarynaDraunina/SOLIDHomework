using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Services
{
    public interface IShoppingCartService
    {
        string Country { get; }
        IEnumerable<OrderItem> OrderItems { get; }
        void Add(OrderItem orderItem);
        decimal TotalAmount();
    }
}
