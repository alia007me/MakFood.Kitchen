using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;

namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate
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
            Check(new NameMustContainOnlyValidCharactersBR(name));

            Id = Guid.NewGuid();
            Name = name;
        }
        private Subcategory() //ef
        {
            
        }

        public string Name { get; set; }

        #region Behaviors
        /// <summary>
        /// نام دسته بندی جزئی را آپدیت می کند
        /// </summary>
        /// <param name="newName">نام جدید دسته بندی جزئی</param>
        public void updateSubcategoryName(string newName)
        {
            Check(new NameMustContainOnlyValidCharactersBR(newName));
            Name = newName;
        }

        /// <summary>
        /// قانون کسب و کار: اگر محصولی در این دسته بندی وجود داشته باشد، امکان حذف ندارد.
        /// </summary>
        /// <param name="hasProducts">وضعیت وجود محصول در این دسته بندی</param>
        public void CheckCanBeRemoved(bool hasProducts)
        {
            if (hasProducts)
                throw new SubCategoryHasProductException(this.Name,this.Id);
            
        }
        #endregion
    }
}
