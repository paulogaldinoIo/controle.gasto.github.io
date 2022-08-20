using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Service_Api.Configuations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ControleEstoque Project",
                    Description = "ControleEsoque Api Swagger surface",
                    Contact = new OpenApiContact {Name = "Paulo Galdino", Email = "josepaulogaldino1@gmail.com", Url = new Uri("https://mail.google.com/mail/u/1/?ogbl#inbox") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/EduardoPires/EquinoxProject/blob/master/LICENSE") }

                });

            });
        }
    }
}
