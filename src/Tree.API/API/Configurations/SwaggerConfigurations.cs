using System.Reflection;

namespace API.Configurations
{
    public static class SwaggerConfigurations
    {
        public static WebApplicationBuilder ConfigureSwagger(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddSwaggerGen(options =>
            {
                options.CustomOperationIds((apiDescription) =>
                $"{apiDescription.ActionDescriptor.RouteValues["controller"]}_{apiDescription.ActionDescriptor.RouteValues["action"]}");

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, true);
            });

            return applicationBuilder;
        }
    }
}
