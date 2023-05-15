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

                options.EnableAnnotations();
            });

            return applicationBuilder;
        }
    }
}
