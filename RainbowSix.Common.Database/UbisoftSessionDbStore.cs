using RainbowSix.Common.Database.Entities;
using RainbowSix.Common;
using RainbowSix.Common.Interfaces;

namespace RainbowSix.Common.Database
{
    public class UbisoftSessionDbStore : IUbisoftSessionStore
    {
        private readonly RainbowSixDbContext _db;
        public UbisoftSessionDbStore(RainbowSixDbContext db)
        {
            _db = db;
        }

        public void DeleteSession(string username)
        {
            _db.Sessions.RemoveRange(_db.Sessions.Where(s => s.Username == username));
            _db.SaveChanges();
        }

        public IUbisoftSession? LoadSessionByUsername(string username)
        {
            var session = _db.Sessions.SingleOrDefault(x => x.Username.ToLower() == username.ToLower());
            return session;
        }

        public IUbisoftSession? LoadSessionBySessionId(string sessionId)
        {
            var session = _db.Sessions.SingleOrDefault(x => x.SessionId == sessionId);
            return session;
        }

        public void SaveSession(string username, IUbisoftSession? session)
        {
            if (session == null || string.IsNullOrEmpty(session.SessionId))
                throw new ArgumentException("session or sessionId is null.");

            DeleteSession(username);

            // Map IUbisoftSession to Session
            var newSession = new Session
            {
                Username = username,
                SessionId = session.SessionId,
                MaskedPhone = session.MaskedPhone,
                PlatformType = session.PlatformType,
                Ticket = session.Ticket,
                TwoFactorAuthenticationTicket = session.TwoFactorAuthenticationTicket,
                ProfileId = session.ProfileId,
                UserId = session.UserId,
                NameOnPlatform = session.NameOnPlatform ?? string.Empty,
                Environment = session.Environment,
                Expiration = session.Expiration,
                SpaceId = session.SpaceId,
                ClientIp = session.ClientIp,
                ClientIpCountry = session.ClientIpCountry,
                ServerTime = session.ServerTime,
                RememberMeTicket = session.RememberMeTicket,
                CodeGenerationPreference = session.CodeGenerationPreference,
                CodeCommunicationPreference = session.CodeCommunicationPreference
            };

            _db.Sessions.Add(newSession);
            
            _db.SaveChanges();
        }
    }
}
