using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using System.Text.Json.Serialization;
using API.Conventions;
using Application.Profiles;
using API.Filters;

namespace API.Configurations
{
    public static class ApiConfigurations
    {
        public static WebApplicationBuilder ConfigureAPI(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddCors();
            applicationBuilder.Services.AddControllers(opt =>
            {
                opt.Conventions.Add(new ControllerNameAttributeConvention());
                opt.Filters.Add(typeof(ResponseOnExceptionFilter));
            }).AddJsonOptions(
                opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            applicationBuilder.Services.AddEndpointsApiExplorer();

            applicationBuilder.Services.AddFluentValidationAutoValidation();
            applicationBuilder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            applicationBuilder.Services.AddAutoMapper(typeof(MapProfile));

            return applicationBuilder;
        }
    }
}