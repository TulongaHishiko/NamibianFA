using NamibianFA.Core.Data;
using NamibianFA.Core.Interfaces;
using NamibianFA.Core.Repositories;
using NamibianFA.Domain.Abstract;
using NamibianFA.Domain.Entities;
using NamibianFA.Domain.Settings;
using NamibianFA.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Core.Configurations
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, DatabaseTypeEnum databaseType)
        {
            switch (databaseType)
            {
                case DatabaseTypeEnum.Local:
                    services.AddDbContext<dContext>(options =>
                    options.UseSqlServer(DatabaseSettings.LocalConnection,
                    option => option.EnableRetryOnFailure()));
                    break;
                case DatabaseTypeEnum.Online:
                    services.AddDbContext<dContext>(options =>
                    options.UseSqlServer(DatabaseSettings.ServerConnection,
                    option => option.EnableRetryOnFailure()));
                    break;
            }

            return services;

        }

        public static IServiceCollection AddIdentityDB(this IServiceCollection services, DatabaseTypeEnum databaseType)
        {
            switch (databaseType)
            {
                case DatabaseTypeEnum.Local:
                    services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(DatabaseSettings.IdentityLocalConnection,
                    option => option.EnableRetryOnFailure()));
                    break;
                case DatabaseTypeEnum.Online:
                    services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(DatabaseSettings.IdentityServerConnection,
                    option => option.EnableRetryOnFailure()));
                    break;
            }

            services.AddIdentity<User, IdentityRole>(options =>
            {
                // example of setting options
                options.Tokens.ChangePhoneNumberTokenProvider = "Phone";

                // password settings chosen due to NIST SP 800-63
                options.Password.RequiredLength = 8; // personally i'd prefer to see 10+
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

            return services;
        }



        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IErrorHandler, ErrorHandler>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
