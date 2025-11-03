using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate
{
    /// <summary>
    /// مدل دسته بندی کلی
    /// </summary>
    public class Category : BaseEntity<Guid>
    {
        private List<Subcategory> _subcategories = new List<Subcategory>();

        /// <summary>
        /// مدل تسک بندی کلی با ورودی تنها یک نام
        /// </summary>
        /// <param name="name">نام دسته بندی کلی</param>
        public Category(string name)
        {
            Id = Guid.NewGuid();
            NameValidation(name);
            Name = name;
        }

        public string Name { get; private set; }


        public IEnumerable<Subcategory> Subcategories => _subcategories.AsReadOnly();


        #region Validators
        private void NameValidation(string name)
        {
            name.CheckNullOrEmpty("name");
            var nameRegexPattern = "([A-Za-z\\s]{0,25})";
            if (Regex.IsMatch(nameRegexPattern, name)) throw new Exception("Product name may have invalid characters or more than 25 characters");
        }

        private void CheckSubcategoryExist(Subcategory subcategory)
        {
            if (_subcategories.Contains(subcategory)) throw new Exception("SubCategory is already exist here");
        }

        #endregion

        #region Behaviors

        /// <summary>
        /// نام دسته بندی کلی را آپدیت می کند
        /// </summary>
        /// <param name="newName">نام جدید دسته بندی کلی</param>
        public void UpdateCategoryName(string newName)
        {
            NameValidation(newName);
            Name = newName;
        }

        /// <summary>
        /// دسته بندی جزئی را به دسته بندی کلی اضافه می کند
        /// </summary>
        /// <param name="subcategory">دسته بندی جزئی</param>
        public void AddSubcategory(Subcategory subcategory)
        {
            CheckSubcategoryExist(subcategory);
            _subcategories.Add(subcategory);
        }

        /// <summary>
        /// دسته بندی جزئی را از دسته بندی کلی حذف می کند
        /// </summary>
        /// <param name="subcategoryId">آیدی دسته بندی جزئی</param>
        public void RemoveSubcategory(Guid subcategoryId)
        {
            var target = _subcategories.FirstOrDefault(x => x.Id == subcategoryId);
            _subcategories.Remove(target);
        }


        #endregion

    }

}
