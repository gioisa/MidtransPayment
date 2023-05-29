using Microsoft.Extensions.DependencyInjection;
using Midtrans.Payment.Shared.Interface;
using Midtrans.Payment.Shared.Helper;

namespace Midtrans.Payment.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterShared(this IServiceCollection services)
        {
            services.AddSingleton<IGeneralHelper, GeneralHelper>();
            services.AddSingleton<IWrapperHelper, WrapperHelper>();
            services.AddSingleton<IHttpRequest, HttpRequest>();

            return services;
        }
    }
}
