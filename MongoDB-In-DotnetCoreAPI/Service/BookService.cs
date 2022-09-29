using MongoDB.Driver;
using MongoDB_In_DotnetCoreAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MongoDB_In_DotnetCoreAPI.Service
{
    public class BookService
    {
        public readonly IMongoCollection<Book> _books;
        public BookService(BookstoreDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);

            _books = database.GetCollection<Book>(setting.BooksCollectionName);
        }

        public List<Book> Get() 
        {
           return  _books.Find(b => true).ToList();
        }

        public Book GetOne(string id) 
        {
            return _books.Find(b => b.Id == id).FirstOrDefault();
        }

        public Book Insert(Book book) 
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book book) 
        {
            var build = Builders<Book>.Update
                                      .Set("BookName", book.BookName)
                                      .Set("Price", book.Price);
            var a = _books.UpdateOne(book => book.Id == id, build);
        }

        public void Delete(string id)
        {
            var build = _books.DeleteOne(b => b.Id == id);
        }
    }
}
