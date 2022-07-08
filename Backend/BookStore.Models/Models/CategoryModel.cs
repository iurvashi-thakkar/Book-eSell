﻿//using System;
//using System.Collections.GEneric;
//using System.Ling;
//using System.Text;
//using System.Threading.Tasks;

using BookStore.Models.ViewModels;

namespace BookStore.Models.Models
{
    public class CategoryModel
    {
        public CategoryModel() { }
           public CategoryModel(Category category)
        {
            Id=category.Id;
            Name=category.Name;

        }
           public int Id { get; set; }
           public string Name { get; set; }
    }
}
