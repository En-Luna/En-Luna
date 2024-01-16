using En_Luna.Email;
using En_Luna.Settings;

namespace En_Luna.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
        }

        public static void RegisterSettings(this WebApplicationBuilder builder)
        {
            var emailConfig = builder.Configuration
                .GetSection("EmailSettings")
                .Get<EmailSettings>();

            builder.Services.AddSingleton(emailConfig);
        }
    }
}
