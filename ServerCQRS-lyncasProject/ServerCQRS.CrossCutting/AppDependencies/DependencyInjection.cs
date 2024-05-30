using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Infrastructure.Context;
using ServerCQRS.Infrastructure.Repositories;
using System.Data;

namespace ServerCQRS.CrossCutting.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var mySqlConnecton = configuration
                .GetConnectionString("DefaultConnection");

            //Conexão para os comandos
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnecton,
                ServerVersion.AutoDetect(mySqlConnecton)));

            //Conexão para as consultas
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new MySqlConnection(mySqlConnecton);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDapperRepository, CustomerDapperRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleDapperRepository, SaleDapperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var myhandlers = AppDomain.CurrentDomain.Load("ServerCQRS.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}
