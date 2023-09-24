using System.Collections.Concurrent;

namespace ART_PACKAGE.Helpers
{
    public class UsersConnectionIds
    {
        private readonly ConcurrentDictionary<string, List<string>> Connections = new();
        private readonly object _lock = new();
        public void AddConnctionIdFor(string user, string connection)
        {
            if (user == null)
                return;
            bool isUserExist = Connections.ContainsKey(user);
            if (isUserExist)
            {
                Connections[user].Add(connection);
            }
            else
            {
                _ = Connections.TryAdd(user, new List<string> { connection });
            }
        }

        public List<string> GetConnections(string user)
        {
            return user == null ? new List<string>() : Connections[user];
        }

        public void RemoveConnection(string user, string connection)
        {
            if (user == null)
                return;
            lock (_lock)
            {
                bool isUserExist = Connections.ContainsKey(user);
                if (isUserExist)
                {
                    string? con = Connections[user].FirstOrDefault(x => x == connection);
                    _ = Connections[user].Remove(con);
                }
            }

        }
    }
}