﻿using SOLIDHomework.Core.Calculators;
using System.Collections.Generic;

namespace SOLIDHomework.Core.Services
{
    //there are OCP and SOC violation
    //
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<OrderItem> orderItems;       
        public string Username { get; set; }
        private readonly IItemCalculator _itemCalculator;
        private readonly ITaxCalculateFactory _taxCalculateFactory;              

        public ShoppingCartService(IItemCalculator itemCalculator, ITaxCalculateFactory taxCalculatFactory)
        {            
            orderItems = new List<OrderItem>();
            _taxCalculateFactory = taxCalculatFactory;
            _itemCalculator= itemCalculator;                   
        }
        
        public IEnumerable<OrderItem> OrderItems
        {
            get { return orderItems; }
        }
        public void Add(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0;

            foreach (var orderItem in OrderItems)
            {
                total += _itemCalculator.CalculateItemTotal(orderItem);
            }

            total = _taxCalculateFactory.GetTaxCalculator(Username).CalculateTax(total);

            return total;
        }
    }
}
