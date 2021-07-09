using System.Collections.Generic;

namespace Burger.Common.Authorization
{
    public interface IUser
    {
        string Id { get; }

        string Name { get; }

        string Role { get; }

        IEnumerable<string> Permissions { get; }
    }
}
