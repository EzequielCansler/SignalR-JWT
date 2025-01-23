//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using EL.Entities;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
//using Microsoft.IdentityModel.Tokens;


//namespace BLL.Services
//{
//    internal sealed class TokenProvider(IConfiguration configuration)
//    {
//        public string Create(User user)
//        {
//            string secretKey = configuration["jwt:Key"]!;
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity
//                    (
//                        [
//                            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                            new Claim("email_verified", user.EmailVerified.ToString()),
//                        ]),
//                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpirationInMinutes")),
//                SigningCredentials = credentials,
//                Issuer = configuration["Jwt:Issuer"],
//                Audience = configuration["Jwt:Audience"]
//            };

//            var handler = new JsonWebTokenHandler();

//            string token = handler.CreateToken(tokenDescriptor);

//            return token;
//        }
//    }
//}
