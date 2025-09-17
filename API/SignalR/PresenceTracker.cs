using System.Collections.Concurrent;

namespace API.SignalR;

public class PresenceTracker
{
    private static readonly ConcurrentDictionary<string,
     ConcurrentDictionary<string, byte>> OnlineUsers =
        new();

    public Task UserConnected(string UserId, string connectionId)
    {
        var connections = OnlineUsers.GetOrAdd(UserId, _ =>
            new ConcurrentDictionary<string, byte>());
        connections.TryAdd(connectionId, 0);
        return Task.CompletedTask;
    }

    public Task UserDisconnected(string UserId, string connectionId)
    {
        if (OnlineUsers.TryGetValue(UserId, out var connections))
        {
            connections.TryRemove(connectionId, out _);
            if (connections.IsEmpty)
                OnlineUsers.TryRemove(UserId, out _);
        }

        return Task.CompletedTask;
    }

    public Task<string[]> GetOnLineUsers()
    {
        return Task.FromResult(OnlineUsers.Keys.OrderBy(k => k).ToArray());
    }

    public static Task<List<string>> GetConnectionsForUser(string UserId)
    {
        if (OnlineUsers.TryGetValue(UserId, out var connections))
        {
            return Task.FromResult(connections.Keys.ToList());
        }

        return Task.FromResult(new List<string>());
    }
}
