using Bookstore.Data;
using Bookstore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
    }
}
