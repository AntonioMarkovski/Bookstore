namespace Bookstore.Service
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Bookstore.Repository.Interfaces;
    using Bookstore.Service.Interfaces;
    using Bookstore.Entities;   

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        #region Helper & Other Methods

        public List<Book> ConvertAllItemsInCartToList(IEnumerable<ShoppingCart> shoppings)
        {
            List<Book> allBookListFromCartByLoggedInUser = new List<Book>();

            foreach (var item in shoppings)
            {
                var book = _bookRepository.GetBookById(item.BookId);
                if (book != null)
                {
                    allBookListFromCartByLoggedInUser.Add(book);
                }
            }

            return allBookListFromCartByLoggedInUser;
        }

        public double CalculateTotalPrice(double totalShipping, List<Book> AllBookListFromCart)
        {
            var result = totalShipping + Math.Round(AllBookListFromCart.Sum(x => x.Price), 2);
            return result;
        }

        public double CalculateTotalWeight(List<Book> AllBookListFromCart)
        {
            var result = Math.Round(AllBookListFromCart.Sum(x => x.Weight), 2);
            return result;
        }

        public Tuple<double, double, double> CalculateTotalShipping(double totalWeightCount, double totalPriceCount)
        {
            if (totalWeightCount <= 0.99)
            {
                var shippingTotal = 0.0;
                return new Tuple<double, double, double>(totalPriceCount, shippingTotal, totalPriceCount);
            }
            else if (totalWeightCount <= 1 && totalWeightCount <= 2)
            {
                var shippingTotal = 0.50;
                var subTotal = totalPriceCount;
                totalPriceCount += shippingTotal;
                return new Tuple<double, double, double>(subTotal, shippingTotal, totalPriceCount);
            }
            else if (totalWeightCount > 2 && totalWeightCount <= 3)
            {
                var shippingTotal = 1.50;
                var subTotal = totalPriceCount;
                totalPriceCount += shippingTotal;
                return new Tuple<double, double, double>(subTotal, shippingTotal, totalPriceCount);
            }
            else
            {
                var shippingTotal = 2.50;
                var subTotal = totalPriceCount;
                totalPriceCount += shippingTotal;
                return new Tuple<double, double, double>(subTotal, shippingTotal, totalPriceCount);
            }
        }

        #endregion
    }
}
