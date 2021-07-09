namespace Burger.Common.Authorization
{
    public interface IUserService
    {
        bool IsAuthenticated { get; }

        IUser User { get; }
    }
}
