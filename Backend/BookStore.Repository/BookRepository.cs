﻿using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository: BaseRepository
    {
        public ListResponse<Book> GetBooks(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = context.Books.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalRecords = query.Count();
            List<Book> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new ListResponse<Book>()
            {
                Results = categories,
                TotalRecords = totalRecords,
            };

        }
        public Book GetBook(int id)
        {
            return context.Books.FirstOrDefault(c => c.Id == id);
        }
        public Book AddBook(Book book)
        {
            var entry = context.Books.Add(book);
            context.SaveChanges();
            return entry.Entity;
        }
        public Book UpdateBook(Book book)
        {
            var entry = context.Books.Update(book);
            return entry.Entity;
        }
        public bool DeleteBook(int id)
        {
            var book = context.Books.FirstOrDefault(c => c.Id == id);
            if (book == null)
                return false;
            var entry = context.Books.Remove(book);
            context.SaveChanges();
            return true;
        }

    }
}
