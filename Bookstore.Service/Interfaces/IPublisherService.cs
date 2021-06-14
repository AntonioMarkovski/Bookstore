using Bookstore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service.Interfaces
{
    public interface IPublisherService
    {
        void Add(Publisher publisher);
        void Edit(Publisher publisher);
        void Delete(int publisherId);

        Publisher GetPublisherById(int id);

        IEnumerable<Publisher> GetAllPublishers();
    }
}
