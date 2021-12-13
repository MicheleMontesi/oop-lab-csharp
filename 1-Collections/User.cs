using System;
using System.Data;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            Age = age;
            FullName = fullName;
            Username = username ?? throw new NoNullAllowedException($"The argument can be null!");
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }

        public bool IsAgeDefined => Age != null;

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
        protected bool Equals(User other) =>
            Age == other.Age && FullName == other.FullName && Username == other.Username;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode() => HashCode.Combine(Age, FullName, Username);

        public override string ToString() =>
            $"{nameof(User)}({nameof(Age)}: {Age}, {nameof(FullName)}: {FullName}, {nameof(Username)}: {Username}";
    }
}
