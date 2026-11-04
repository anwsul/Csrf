using Microsoft.Extensions.Caching.Memory;
using MyBank.Models;

namespace MyBank.Services
{
    public static class UserService
    {
        // on signup, add users to an in memory db.
        public static void CreateUser(User user, IMemoryCache memoryCache)
        {
            Dictionary<string, User> users = (Dictionary<string, User>?)memoryCache.Get("users") ?? new Dictionary<string, User>() { { user.Username, user } };
            users.TryAdd(user.Username, user);
            memoryCache.Set("users", users);
        }

        // given a session, retrieve the user object.
        public static User? GetUserFromSesssion(ISession session)
        {
            string? sessionString = session.GetString("auth");

            if (sessionString != null)
            {
                return new User
                {
                    Username = sessionString.Split(',')[0].Split('=')[1],
                    Password = sessionString.Split(',')[1].Split('=')[1],
                };
            }

            return null;
        }

        // on successful login/signup, give the authtenicated user a session.
        public static bool SetSession(User user, ISession session, IMemoryCache memoryCache)
        {
            Dictionary<string, User>? users = (Dictionary<string, User>?) memoryCache.Get("users");
            if (users != null &&
                users.TryGetValue(user.Username, out User? storedUser) &&
                user.Password == storedUser.Password)
            {
                session.SetString("auth", user.ToString());
                return true;
            }

            return false;
        }

    }
}
