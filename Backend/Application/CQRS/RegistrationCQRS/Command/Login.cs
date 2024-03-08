using AutoMapper;
using Domain;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.CQRS.RegistrationCQRS.Command
{
    public class Login : IRequest<string>
    {
        public LoginDTO? LoginDTO { get; set; }
    }
    public class LoginHandler : IRequestHandler<Login, string>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _config;

        public LoginHandler(IMapper mapper, IApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _config = configuration;
        }

        public async Task<string> Handle(Login request, CancellationToken cancellationToken)
        {;
            var aa = new User { Username = request.LoginDTO.Username, Password = request.LoginDTO.Password };
            var user = await AuthenticateUser(aa);
            if (user != null)
            {
                var token = GenerateToken();
                var result = true;
                var responseMessage = new IdResponse(token, result, 200,id:user.Id);
                var jsonresponse = JsonConvert.SerializeObject(responseMessage);
                return jsonresponse;
            }
            return "Invalid Username or Password";
        }

             async Task<User> AuthenticateUser(User user)
            {
                var users = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
                if (users != null)
                {
                    return users;
                }
                else
                {
                    return null;
                }
            }

             string GenerateToken()
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                    expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

        }
    }

