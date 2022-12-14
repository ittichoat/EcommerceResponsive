using EcommerceResponsive.Service.Interface;
using EcommerceResponsive.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add scope
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddMemoryCache();

//Add Policy
builder.Services.AddCors(option => option.AddDefaultPolicy(policy => { policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); ; }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();


