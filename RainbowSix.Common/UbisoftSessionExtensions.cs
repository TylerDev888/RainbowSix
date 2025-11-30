using RainbowSix.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSix.Common
{
    public static class UbisoftSessionExtensions
    {
        public static bool IsSessionExpired(this IUbisoftSession? session)
        {
            return session == null
                || session.SessionId == null
                || session.UserId == null
                || DateTime.Now >= session.Expiration;
        }

        public static bool Is2faRequired(this IUbisoftSession? session)
        {
            return !string.IsNullOrEmpty(session?.TwoFactorAuthenticationTicket);
        }
    }
}
