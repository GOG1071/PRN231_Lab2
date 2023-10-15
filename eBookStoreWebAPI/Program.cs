using BusinessObject;
using eBookStoreWebAPI;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Book>("Books");
modelBuilder.EntitySet<Author>("Authors");
modelBuilder.EntityType<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });
modelBuilder.EntitySet<BookAuthor>("BookAuthors");
modelBuilder.EntitySet<Publisher>("Publishers");
modelBuilder.EntitySet<Role>("Roles");
modelBuilder.EntitySet<User>("Users");

builder.Services.AddControllers().AddOData(opt =>
{
    opt.Select().Filter().Count().OrderBy().OrderBy().Expand().SetMaxTop(100)
        .AddRouteComponents("odata", modelBuilder.GetEdmModel());
    opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();