using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class SessionBusiness
    {
        private SessionData sessionData;

        public SessionBusiness(String connString)
        {
            this.sessionData = new SessionData(connString);
        }

        public String login(String username, String password)
        {
            return this.sessionData.login(username, password);
        }

    }
}
