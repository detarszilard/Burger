using System.Collections.Generic;

namespace Burger.Common.Authorization
{
    public class User : IUser
    {
        public string Id { get; }

        public string Name { get; }

        public string Role { get; }

        public IEnumerable<string> Permissions { get; }

        public User(string id, string name, string role, IEnumerable<string> permissions)
        {
            Id = id;
            Name = name;
            Role = role;
            Permissions = permissions;
        }
    }
}
