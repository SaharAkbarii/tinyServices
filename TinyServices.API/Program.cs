using Microsoft.EntityFrameworkCore;
using TinyServices.API.LinkService.AppServices;
using TinyServices.API.Repository;
using AutoMapper.Extensions;
using Microsoft.Extensions.DependencyInjection;
using TinyServices.API.Divar.AppService;
using TinyServices.API.Linkedin.AppService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ShortLinkService).Assembly);
builder.Services.AddScoped<ShortLinkService>();
builder.Services.AddScoped<DeepLinkService>();
builder.Services.AddScoped<OneTimeLinkService>();
builder.Services.AddScoped<LinkInsightService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<CategoryAppService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<AdvertisementAppService>();
builder.Services.AddScoped<LinkedinUserAppService>();
builder.Services.AddScoped<LinkedinPostAppService>();
builder.Services.AddDbContext<TinyServicesDbContext>(b =>
            {
                string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings");
                b.UseNpgsql(connectionString);
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


