﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deepcove_Trust_Website.Features.Emails
{
    public interface IEmailService
    {
        Task SendEmailAsync(
            EmailContact Sender,
            EmailContact Recipient,
            string subject,
            string message
        );

        Task SendRazorEmailAsync(
            EmailContact Sender,
            EmailContact Recipient,
            string subject,
            string viewName,
            object vars
        );

        Task SendGeneralInquiryAsync(
            EmailContact Sender,
            string subject,
            object vars
        );

        Task SendBookingInquiryAsync(
            EmailContact Sender,
            string subject,
            object vars
        );
    }
}
