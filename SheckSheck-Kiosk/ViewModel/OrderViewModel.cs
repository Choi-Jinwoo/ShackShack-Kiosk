﻿using SheckSheck_Kiosk.Model;
using SheckSheck_Kiosk.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SheckSheck_Kiosk.ViewModel
{
    class OrderViewModel
    {
        private CategoryDao categoryDao = new CategoryDao();
        private FoodDao foodDao = new FoodDao();

        public List<Category> Categories { get; set; }
        public List<Food> Foods { get; set; }
        public int PageCount { get; set; } = 0;
        public Category SelectedCategory;

        public OrderViewModel()
        {
            Categories = categoryDao.GetCategories();
            Foods = foodDao.GetFoods();

            if (Categories.Count > 0)
            {
                SelectedCategory = Categories[0];
            }
        }

        public List<Food> GetSelectedCategoryFoods() => Foods.Where(x => x.CategoryId == SelectedCategory.Id).ToList();
        public List<Food> GetSelectedCategoryFoods(int takeCount) {
            List<Food> foods = Foods
                                .Where(x => x.CategoryId == SelectedCategory.Id)
                                .Take(takeCount)
                                .ToList();
            return foods;
        }
        public List<Food> GetSelectedCategoryFoods(int skipCount, int takeCount) => Foods
                                .Where(x => x.CategoryId == SelectedCategory.Id)
                                .Skip(skipCount)
                                .Take(takeCount)
                                .ToList();
    }
}
