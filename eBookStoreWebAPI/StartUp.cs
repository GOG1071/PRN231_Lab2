namespace eBookStoreWebAPI;

using BusinessObject;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

public class StartUp
{
    public StartUp(IConfiguration configuration) { this.Configuration = configuration; }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EBookStoreDbContext>(o => o.UseInMemoryDatabase("EBookStoreDb"));
        serviceCollection.AddControllers();

        serviceCollection.AddControllers().AddOData(opt =>
        {
            opt.Select().Filter().Count().OrderBy().OrderBy().Expand().SetMaxTop(100)
                .AddRouteComponents("odata", GetEdmModel());
            opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
        }

        app.UseODataBatching();

        app.UseRouting();

        app.Use(next => context =>
        {
            var endpoint = context.GetEndpoint();
            if (endpoint == null) return next(context);
            IEnumerable<string> templates;
            var                 metaData    = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
            if (metaData != null) templates = metaData.Template.GetTemplates();

            return next(context);
        });
        
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<Book>("Books");
        builder.EntitySet<Author>("Authors");
        builder.EntitySet<BookAuthor>("BookAuthors");
        builder.EntitySet<Publisher>("Publishers");
        builder.EntitySet<Role>("Roles");
        builder.EntitySet<User>("Users");
        
        return builder.GetEdmModel();
    }
}