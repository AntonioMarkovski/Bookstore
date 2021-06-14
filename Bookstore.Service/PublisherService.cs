using Bookstore.Entities;
using Bookstore.Repository.Interfaces;
using Bookstore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            _publisherRepository.AddPublisher(publisher);
        }

        public void Delete(int publisherId)
        {
            _publisherRepository.DeletePublisher(publisherId);
        }

        public void Edit(Publisher publisher)
        {
            _publisherRepository.EditPublisher(publisher);
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            var result = _publisherRepository.GetAllPublishers();
            return result;
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _publisherRepository.GetPublisherById(id);
            return result;
        }
    }
}
