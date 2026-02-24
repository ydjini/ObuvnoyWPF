using ObuvnoyWPF.Database;
using ObuvnoyWPF.Models;
using ObuvnoyWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnoyWPF.Controllers
{
    public class CategoryController
    {
        private DatabaseContext _dbContext = new();
        private MessageManager _message = new();
        
        public int GetLastCategoryId()
        {
            return _dbContext.Categories.Last().Id;
        }

        public void AddNewCategory(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                categoryName = categoryName.Trim();
                var newCategory = new Category { Name = categoryName };
                _dbContext.Categories.Add(newCategory);
                _dbContext.SaveChanges();
                _message.Success("Успешно добавлено.");
            }
            else
            {
                _message.Error("Имя не может быть пустым.");
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.Find(categoryId);
        }

        public void RemoveCategoryById(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            _message.Success("Успешно удалено!");
        }

        public void UpdateCategoryById(Category udpatedCategory)
        {
            var existingCategory = GetCategoryById(udpatedCategory.Id);
            if (existingCategory != null)
            {
                _dbContext.Entry(existingCategory).CurrentValues.SetValues(udpatedCategory);
                _dbContext.SaveChanges();
                _message.Success("Успешно обновлено.");
            }
        }
    }
}
