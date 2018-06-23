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

        public String register(String username, String password, int age, char gender)
        {
            return this.sessionData.register(username, password, age, gender);
        }

    }
}
