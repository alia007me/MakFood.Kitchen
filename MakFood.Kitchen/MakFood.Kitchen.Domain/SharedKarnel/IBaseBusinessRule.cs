namespace MakFood.Kitchen.Domain.SharedKarnel
{
    public interface IBaseBusinessRule 
    {
        bool Check();
        Exception Throws();
    }
}
