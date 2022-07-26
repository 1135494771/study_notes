using System;
using System.Collections.Generic;
using System.Text;

namespace MailServices
{
    public interface IMailServer
    {
        void sendMail(string content);
    }
}
