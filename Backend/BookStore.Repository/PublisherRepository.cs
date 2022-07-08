﻿using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class PublisherRepository : BaseRepository
    {
        public ListResponse<Publisher> GetPublishers(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = context.Publishers.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalReocrds = query.Count();
            List<Publisher> categories = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Publisher>()
            {
                Results = categories,
                TotalRecords = totalReocrds,
            };
        }

        public Publisher GetPublisher(int id)
        {
            return context.Publishers.FirstOrDefault(c => c.Id == id);
        }

        public Publisher AddPublisher(Publisher category)
        {
            var entry = context.Publishers.Add(category);
            context.SaveChanges();
            return entry.Entity;
        }

        public Publisher UpdatePublisher(Publisher category)
        {
            var entry = context.Publishers.Update(category);
            context.SaveChanges();
            return entry.Entity;
        }

        public bool DeletePublisher(int id)
        {
            var category = context.Publishers.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return false;

            context.Publishers.Remove(category);
            context.SaveChanges();
            return true;
        }
    }
}
