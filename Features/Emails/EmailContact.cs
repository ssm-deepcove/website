﻿using MimeKit;

namespace Deepcove_Trust_Website.Features.Emails
{
    public class EmailContact
    {
        public string Name;

        public string Address;

        public MailboxAddress ToMailboxAddress()
        {
            return new MailboxAddress(Name, Address);
        }
    }
}
