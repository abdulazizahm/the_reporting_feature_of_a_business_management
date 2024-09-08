using AWP.DAL.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using AWP.Helper;
using AWP.REPO;
using AWP.Helpers;
using AWP.Business;
using Microsoft.AspNetCore.Identity.UI.Services;
using AWP.Business.Settings;
using Microsoft.OpenApi.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Mvc;
using AWP.API.Filter;

namespace AWP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //  builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            builder.Services.AddDbContext<AWPContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("AWPCS")
            ));
          
              
    
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

           
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;


            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AWPContext>();
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddControllers(options =>
            {
              
                options.Filters.Add<ExceptionFilter>();
            });




            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<AuthManager, AuthManager>();
            builder.Services.AddScoped<CountryManager, CountryManager>();
            builder.Services.AddScoped<QuestionaireManager, QuestionaireManager>();
            builder.Services.AddScoped<UsersDataManager, UsersDataManager>();
            builder.Services.AddScoped<InverstorTypeManager, InverstorTypeManager>();
            builder.Services.AddScoped<LookupManager, LookupManager>();
            builder.Services.AddScoped<PropertyManager, PropertyManager>();
            builder.Services.AddScoped<FileService, FileService>();
            builder.Services.AddScoped<SettingsManager, SettingsManager>();
            builder.Services.AddScoped<PropertyInquiryManager, PropertyInquiryManager>();
            builder.Services.AddScoped<WebSiteHomePageManager, WebSiteHomePageManager>();
            builder.Services.AddScoped<HelpManager, HelpManager>();
            builder.Services.AddScoped<AccountManager, AccountManager>();
            builder.Services.AddScoped<InnerPageManager, InnerPageManager>();
            builder.Services.AddScoped<ProjectManager, ProjectManager>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.OperationFilter<CustomHeaderSwaggerAttribute>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
            builder.Services.Configure<ApiBehaviorOptions>(
            options => options.SuppressModelStateInvalidFilter = true
            );
         
            var app = builder.Build();
            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AWPContext>();
                // Apply pending migrations
                dbContext.Database.Migrate();
            }
            app.UseCors("AllowSpecificOrigin");
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
                app.UseSwaggerUI();
           // }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}