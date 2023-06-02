using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TradingProject.Business.Abstract;
using TradingProject.Business.Concrete;
using TradingProject.Business.Rules;
using TradingProject.Business.SecurityServices;

namespace TradingProject.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //    services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            //    services.AddScoped<CategoryBusinessRules>();
            //    services.AddScoped<SubcategoryBusinessRules>();
            //    services.AddScoped<ProductBusinessRules>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ISubcategoryService, SubcategoryManager>();
            services.AddScoped<IAuthsService, AuthsManager>();
            services.AddScoped<IAuthService, AuthManager> ();
            services.AddScoped<IProductService, ProductManager>();

        //    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        //    //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        //    //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        //    //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        //    services.AddScoped<IAuthService, AuthManager>();


            return services;

        }
    }
}
