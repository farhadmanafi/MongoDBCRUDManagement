using Microsoft.OpenApi.Models;
using MongoDBCRUD.Configuration;
using MongoDBPersistent.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Host.ConfigureServices((hostBuilderContext, services) =>
{
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDB CRUD Management API V1", Version = "v1" });
    });

    AppConfigurator.ConfigMongoDb(services, hostBuilderContext);

    services.AddScoped<IProductRepository, ProductRepository>();

    services.AddControllers();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDB CRUD Management API V1");
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
