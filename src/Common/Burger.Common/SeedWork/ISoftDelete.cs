namespace Burger.Common.SeedWork
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }

        void Delete();
    }
}
