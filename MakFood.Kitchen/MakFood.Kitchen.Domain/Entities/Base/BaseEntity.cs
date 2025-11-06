using MakFood.Kitchen.Domain.SharedKarnel;

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

        public static void Check(IBaseBusinessRule rule)
        {
            if (!rule.Check())
                throw rule.Throws();
        }

        public static async Task Check(IAsyncBaseBusinessRule rule, CancellationToken ct)
        {
            if (!await rule.Check(ct))
                throw rule.Throws();
        }
    }
}
