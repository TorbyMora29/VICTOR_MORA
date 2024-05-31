using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoJwt.Infraestructura.Utilidades;
using ProyectoJwt.Persistencia;
using ProyectoJwt.Persistencia.Comunes;
using System.Text;

namespace ProyectoJwt.Api.Extensiones
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection ConfigurarContexto(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProyectoJwtDbContext>(
                options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"],
                    x => x.MigrationsHistoryTable(
                        ConstantesPersistencia.m_MigrationHistoryTableName,
                        ConstantesPersistencia.m_DefaultSchema)
                    ), 
                ServiceLifetime.Scoped);

            return services;
        }

        public static IServiceCollection ConfigurarJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new
                        SymmetricSecurityKey(CodificadorUtil.DecodificarAByte(configuration["Jwt:Key"]!))
                    };
                });

            return services;
        }
    }
}
