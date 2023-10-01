using ForouzanTask.Application.Services.Implementations;
using ForouzanTask.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ForouzanTask.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOuterUserProjectService, OuterUserProjectService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IArticleAdminService, ArticleAdminService>();
            services.AddScoped<IHomeService, HomeService>();
        }
    }
}
