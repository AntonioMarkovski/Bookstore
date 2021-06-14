namespace Bookstore.Repository.Interfaces
{
    using Bookstore.Entities;
    using System.Collections.Generic;

    public interface IPublisherRepository
    {
        void AddPublisher(Publisher publisher);
        void EditPublisher(Publisher publisher);
        void DeletePublisher(int publisherId);

        Publisher GetPublisherById(int id);

        IEnumerable<Publisher> GetAllPublishers();
    }
}
