namespace MakFood.Kitchen.Domain.Entities.Base
{
    public abstract class BaseEntity<TId>
    {
        protected BaseEntity()
        {
            CreationDateTime = DateTime.Now;
        }

        public TId Id { get; protected set; }
        public DateTime CreationDateTime { get; private set; }
    }
}
