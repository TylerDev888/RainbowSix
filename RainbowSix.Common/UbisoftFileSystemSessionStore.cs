using RainbowSix.Common.Interfaces;
using RainbowSix.Common.Models.Response;
using System;
using System.IO;
using System.Text.Json;

namespace RainbowSix.Common
{
    public class UbisoftFileSystemSessionStore : IUbisoftSessionStore
    {
        private readonly string _baseSessionPath;

        public UbisoftFileSystemSessionStore(string? baseSessionPath = null)
        {
            _baseSessionPath = baseSessionPath ?? Path.GetTempPath();
        }

        private string GetSessionPath(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
                throw new ArgumentException("sessionId must not be null or empty.", nameof(sessionId));

            return Path.Combine(_baseSessionPath, $"ubisoft_session_{sessionId}.json");
        }

        public void SaveSession(string username, IUbisoftSession? authResponse)
        {
            if (authResponse is null || string.IsNullOrWhiteSpace(authResponse.SessionId))
                throw new ArgumentException("authResponse or sessionId is null.");

            authResponse.Username = username;

            File.WriteAllText(GetSessionPath(authResponse.SessionId), JsonSerializer.Serialize(authResponse));
        }

        public IUbisoftSession? LoadSessionByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username must not be null or empty.", nameof(username));
            var files = Directory.GetFiles(_baseSessionPath, "ubisoft_session_*.json");
            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                if (!string.IsNullOrEmpty(content))
                {
                    var auth = JsonSerializer.Deserialize<UbisoftAuthResponseModel>(content);
                    if (auth != null && string.Equals(auth.Username, username, StringComparison.OrdinalIgnoreCase))
                    {
                        return auth;
                    }
                }
            }
            return null;
        }

        public IUbisoftSession? LoadSessionBySessionId(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
                throw new ArgumentException("sessionId must not be null or empty.", nameof(sessionId));

            var path = GetSessionPath(sessionId);
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(content))
                {
                    return JsonSerializer.Deserialize<UbisoftAuthResponseModel>(content);
                }
            }
            return null;
        }

        public void DeleteSession(string sessionId)
        {
            var path = GetSessionPath(sessionId);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
