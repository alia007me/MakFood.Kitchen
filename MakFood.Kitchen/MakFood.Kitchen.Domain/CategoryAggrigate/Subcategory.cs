using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;

namespace MakFood.Kitchen.Domain.CategoryAggrigate
{
    /// <summary>
    /// دسته بندی جزئی
    /// </summary>
    public class Subcategory : BaseEntity<Guid>
    {
        /// <summary>
        /// دسته بندی جزئی برای ایجاد تنها به یک نام نیاز دارد
        /// </summary>
        /// <param name="name">نام دسته بندی جزئی</param>
        public Subcategory(string name)
        {
            Id = Guid.NewGuid();
            NameValidation(name);
            Name = name;
        }

        public string Name { get; set; }




        #region Validators
        private void NameValidation(string name)
        {
            name.CheckNullOrEmpty("name");
            var nameRegexPattern = "([A-Za-z\\s]{0,25})";
            if (Regex.IsMatch(nameRegexPattern, name)) throw new Exception("Product name may have invalid characters or more than 25 characters");
        }

        #endregion

        #region Behaviors
        /// <summary>
        /// نام دسته بندی جزئی را آپدیت می کند
        /// </summary>
        /// <param name="newName">نام جدید دسته بندی جزئی</param>
        public void updateSubcategoryName(string newName)
        {
            NameValidation(newName);
            Name = newName;
        }
        #endregion
    }
}
