using Dashboard.Repository.CustomerRepository;
using Dashboard.Repository.SaleRepository;
using Dashboard.Repository.UserRepository;
using Dashboard.Service.CustomerService;
using Dashboard.Service.SaleService;
using Dashboard.Service.UserService;
using Microsoft.EntityFrameworkCore;
using Dashboard.Domain.Mappers;
using Domain.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(CustomerMapper), typeof(SaleMapper), typeof(UserMapper));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature =
            context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

        await context.Response.WriteAsJsonAsync(new
        {
            error = "Internal Server Error",
            details = exceptionHandlerPathFeature?.Error.Message
        });
    });
});

app.MapControllers();

app.Run();