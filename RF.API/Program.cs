using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReportingFeature.Business;
using ReportingFeature.DAL.Models;
using ReportingFeature.Helper;
using ReportingFeature.REPO;

var builder = WebApplication.CreateBuilder(args);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("*")  // Allow all origins; change this in production
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// AutoMapper Configuration
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context Configuration
builder.Services.AddDbContext<RFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RFCS")));

// Dependency Injection
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ReportManager, ReportManager>();

builder.Services.AddControllers();

var app = builder.Build();

// Error Handling and Swagger Configuration
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Detailed error page
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
