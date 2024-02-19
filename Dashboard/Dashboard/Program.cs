using Dashboard.Repository.UserRepository;
using Dashboard.Repository.CustomerRepository;
using Dashboard.Repository.SaleRepository;
using Dashboard.Service.CustomerService;
using Dashboard.Service.SaleService;
using Dashboard.Service.UserService;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Dashboard.Domain.Mappers;
using Dashboard.Repository.RepositoryPattern;
using Dashboard.Dashboard.Service.SaleService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(CustomerMapper),typeof(SaleMapper));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

app.MapControllers();

app.Run();