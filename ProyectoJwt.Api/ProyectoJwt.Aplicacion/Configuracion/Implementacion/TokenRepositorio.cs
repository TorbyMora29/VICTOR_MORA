using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoJwt.Aplicacion.Configuracion.Interfaces;
using ProyectoJwt.Dto.Configuracion;
using ProyectoJwt.Infraestructura.Utilidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProyectoJwt.Aplicacion.Configuracion.Implementacion
{
    internal class TokenRepositorio : ITokenRepositorio
    {
        private const double EXPIRY_DURATION_MINUTES = 30;
        private readonly IConfiguration _configuration;

        public TokenRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Result EsTokenValido(string token)
        {
            var mySecret = CodificadorUtil.DecodificarAByte(_configuration["Jwt:Key"]!);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return Result.Fail("Token inválido");
            }
            return Result.Ok();
        }

        public Result<string> GenerarToken(UsuarioDto.RequestToken user)
        {
            try
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Usuario),
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                };

                var securityKey = new SymmetricSecurityKey(CodificadorUtil.DecodificarAByte(_configuration["Jwt:Key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                    expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);

                return Result.Ok(new JwtSecurityTokenHandler().WriteToken(tokenDescriptor));
            }
            catch (Exception)
            {
                return Result.Fail("Error al generar token");
            }
        }
    }
}