using Microsoft.EntityFrameworkCore;
using Services;

public static class DependentServices
{
    public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        // builder.Services.AddDbContext<InvoeaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
        builder.Services.AddScoped<IInvoiceRepository, InvoiceRespository>();
        return builder;
    }
}