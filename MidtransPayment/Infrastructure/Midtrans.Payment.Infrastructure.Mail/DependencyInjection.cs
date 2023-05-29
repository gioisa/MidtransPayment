using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Midtrans.Payment.Infrastructure.Mail.Interface;
using Midtrans.Payment.Infrastructure.Mail.Service;
using Midtrans.Payment.Infrastructure.Mail.Object;

namespace Midtrans.Payment.Infrastructure.Mail
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterMail(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailConfig>(options => configuration.Bind(nameof(MailConfig), options));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IPaymentService, PaymentService>();

            return services;
        }
    }
}
