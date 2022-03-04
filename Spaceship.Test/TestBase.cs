using Microsoft.Extensions.DependencyInjection;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spaceship.Test
{
    public abstract class TestBase //: IDisposable
    {
        //protected IServiceProvider _serviceProvider;

        //protected TestBase()
        //{
        //    var services = new ServiceCollection();
        //    SetupServices(services);
        //    _serviceProvider = services.BuildServiceProvider();
        //}

        //public virtual void SetupServices(IServiceCollection services)
        //{
        //    services.AddScoped<ISpaceshipService, SpaceshipServices>();
        //}

        //public void Dispose()
        //{
            
        //}

        //protected T Svc<T>()
        //{
        //    return ServiceProvider.GetService<T>();
        //}
    }
}
