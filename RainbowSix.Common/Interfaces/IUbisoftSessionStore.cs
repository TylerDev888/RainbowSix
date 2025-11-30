using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowSix.Common.Interfaces
{
    public interface IUbisoftSessionStore
    {
        void SaveSession(string username, IUbisoftSession? session);
        IUbisoftSession? LoadSessionByUsername(string username); 
        IUbisoftSession? LoadSessionBySessionId(string sessionId);
        void DeleteSession(string username);
    }
}
