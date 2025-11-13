using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate
{
    /// <summary>
    /// مدل دسته بندی کلی
    /// </summary>
    public class Category : BaseEntity<Guid>
    {
        private Category()
        {

        }
        private List<Subcategory> _subcategories = new List<Subcategory>();

        /// <summary>
        /// مدل تسک بندی کلی با ورودی تنها یک نام
        /// </summary>
        /// <param name="name">نام دسته بندی کلی</param>
        public Category(string name)
        {
            Check(new NameMustContainOnlyValidCharactersBR(name));

            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; private set; }


        public IEnumerable<Subcategory> Subcategories => _subcategories.AsReadOnly();


        #region Validators


        private void CheckSubcategoryExist(Subcategory subcategory)
        {
            if (_subcategories.Contains(subcategory)) throw new IsAlreadyExistException();
        }

        #endregion

        #region Behaviors

        /// <summary>
        /// نام دسته بندی کلی را آپدیت می کند
        /// </summary>
        /// <param name="newName">نام جدید دسته بندی کلی</param>
        public void UpdateCategoryName(string newName)
        {
            Check(new NameMustContainOnlyValidCharactersBR(newName));
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

        /// <summary>
        /// قانون کسب و کار: اگر محصولی در این دسته بندی وجود داشته باشد، امکان حذف ندارد.
        /// </summary>
        /// <param name="hasProducts">وضعیت وجود محصول در این دسته بندی</param>
        public void CheckCanBeRemoved(bool hasProducts)
        {
            if (hasProducts)
                throw new EntityHasRelatedItemsException(
            $"Category '{this.Name}' (ID: {this.Id}) cannot be removed because it has related products.");
            
        }


        #endregion

    }
}


