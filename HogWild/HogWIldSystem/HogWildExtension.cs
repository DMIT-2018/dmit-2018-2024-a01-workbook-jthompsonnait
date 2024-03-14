﻿using HogWildSystem.BLL;
using HogWIldSystem.BLL;
using HogWildSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HogWIldSystem
{
    public static class HogWildExtension
    {
        // This is an extension method that extends the IServiceCollection interface.
        // It is typically used in ASP.NET Core applications to configure and register services.

        // The method name can be anything, but it must match the name used when calling it in
        // your Program.cs file using builder.Services.XXXX(options => ...).
        public static void AddBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            // Register the HogWildContext class, which is the DbContext for your application,
            // with the service collection. This allows the DbContext to be injected into other
            // parts of your application as a dependency.

            // The 'options' parameter is an Action<DbContextOptionsBuilder> that typically
            // configures the options for the DbContext, including specifying the database
            // connection string.

            services.AddDbContext<HogWildContext>(options);
            //  adding any services that you create in the class library (BLL)
            //  using .AddTransient<t>(...)
            //  working versions
            services.AddTransient<WorkingVersionService>((ServiceProvider) =>
            {
                //  Retrieve an instance of HogWildContext from the service provider.
                var context = ServiceProvider.GetService<HogWildContext>();

                // Create a new instance of WorkingVersionsService,
                //   passing the HogWildContext instance as a parameter.
                return new WorkingVersionService(context);
            });

            services.AddTransient<CustomerService>((ServiceProvider) =>
            {
                //  Retrieve an instance of HogWildContext from the service provider.
                var context = ServiceProvider.GetService<HogWildContext>();

                // Create a new instance of WorkingVersionsService,
                //   passing the HogWildContext instance as a parameter.
                return new CustomerService(context);
            });

            services.AddTransient<CategoryLookupService>((ServiceProvider) =>
            {
                //  Retrieve an instance of HogWildContext from the service provider.
                var context = ServiceProvider.GetService<HogWildContext>();

                // Create a new instance of WorkingVersionsService,
                //   passing the HogWildContext instance as a parameter.
                return new CategoryLookupService(context);
            });
        }
    }
}
