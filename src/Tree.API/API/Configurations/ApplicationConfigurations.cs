using Application.Mediator.Journal;

namespace API.Configurations
{
    public static class ApplicationConfigurations
    {
        public static WebApplicationBuilder AddApplication(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetJournalRangeRequest>());

            return applicationBuilder;
        }
    }
}
