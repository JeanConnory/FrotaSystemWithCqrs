namespace FrotaApp.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; private set; }

        public CategoryEntity(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
