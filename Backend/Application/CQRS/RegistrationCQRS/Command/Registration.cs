using Application.MailRespo;
using Domain;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.CQRS.RegistrationCQRS.Command
{
    public class Registration:IRequest<ResponseMessage>
    {
        public SignUpDTO? User { get; set; }
    }
    public class RegistrationHandler : IRequestHandler<Registration, ResponseMessage>
    {
       private readonly IApplicationDbContext _context;
        private readonly IMailService _mailService;
        public RegistrationHandler(IApplicationDbContext dbContext, IMailService mailService)
        {
            _context = dbContext;
            _mailService = mailService;
        }

        public async Task<ResponseMessage> Handle(Registration registration,CancellationToken cancellationToken)
        {
            try
            {
                var toUpper = registration.User.FirstName.ToUpper();
                char lastLetter = toUpper[toUpper.Length - 1];

                var lastname = registration.User.LastName.ToUpper();

                var date = registration.User.DOB;
                var dateFormat = date.Substring(date.Length - 2);

                var username = "AS_" + lastname + lastLetter + dateFormat;
                var password = RandomString();

                var user = new User()
                {
                    FirstName = registration.User.FirstName,
                    LastName = registration.User.LastName,
                    Email = registration.User.Email,
                    DOB = registration.User.DOB,
                    Username = username,
                    Password = password,
                    IsActive = 1,
                };

                await _context.Users.AddAsync(user);
                await _mailService.SendUsernamePassword(registration.User.Email,username, password);
                await _context.SaveChangesAsync();
                return new ResponseMessage("Registration Successfull", true, 200,new RegistrationInfo { Username = user.Username,Password = user.Password});

            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
            

        }
    public string RandomString()
    {
        var random = new Random();
        string str = "ABCDEgHIJKLMN129647OPQrstuvwXYZ";
        string ran = string.Empty;
        int size = 10;

        for(int i=0;i<size;i++)
        {
            int x = random.Next(10);
            ran = ran + str[x];
        }

        return ran;
    }
    }

}
