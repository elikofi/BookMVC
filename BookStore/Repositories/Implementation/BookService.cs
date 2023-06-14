using System;
using BookStore.Models;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implementation
{
	public class BookService : IBookService
	{

        private readonly DatabaseContext context;

        public BookService(DatabaseContext context)
        {
            this.context = context;
        }




        public bool Add(Book model)
        {
            try
            {
                context.Books.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null) return false;

                context.Books.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return context.Books.Find(id)!;
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in context.Books
                        select new Book
                        {
                            Id = book.Id,
                            Name = book.Name,
                            Category = book.Category,
                            Price = book.Price,
                            Description = book.Description
                        }).ToList();
            return data;
        }

        public IEnumerable<Book> GetBySearch()
        {
            var data = (from book in context.Books
                        select new Book
                        {
                            Id = book.Id,
                            Name = book.Name,
                            Category = book.Category,
                            Price = book.Price,
                            Description = book.Description
                        }).ToList();
            return data;
        }

        public bool Update(Book model)
        {
            try
            {
                context.Books.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

