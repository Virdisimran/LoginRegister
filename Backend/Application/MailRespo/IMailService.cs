using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MailRespo
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendUsernamePassword(string userEmail, string username, string password);
    }
}
