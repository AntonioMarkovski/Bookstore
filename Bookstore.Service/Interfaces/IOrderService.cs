namespace Bookstore.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Bookstore.Entities;
   
    public interface IOrderService
    {
        //void Add(Order order);
        //void Edit(Order order);
        //void Delete(int id);
        //void DeleteByBookId(int bookID);
        //void DeleteByUserId(string userID);

        //Order GetOrderById(int id);
        //Order GetOrderByBookId(int bookID);
        //Order GetOderByUserId(string userID);

        //IEnumerable<Order> GetAllOrders();
        //IEnumerable<Order> GetAllOrdersByUserId(string userID);
        //IEnumerable<Order> GetAllOrdersByBookId(string bookID);
        //IQueryable<Order> GetAllOrdersQueryable();

        #region Helper Methods

        List<Book> ConvertAllItemsInCartToList(IEnumerable<ShoppingCart> shoppings);
        double CalculateTotalPrice(double totalShipping, List<Book> AllBookListFromCart);
        double CalculateTotalWeight(List<Book> AllBookListFromCart);
        Tuple<double, double, double> CalculateTotalShipping(double totalWeightCount, double totalPriceCount);
        
        #endregion
    }
}
