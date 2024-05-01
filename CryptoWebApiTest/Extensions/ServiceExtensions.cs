namespace CryptoWebApiTest.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string hostToAllow)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(hostToAllow)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
        }
    }
}
