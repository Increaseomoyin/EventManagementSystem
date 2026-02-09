using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.Interfaces.Email;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using EventManagementSystem.Infrastructure.Repositories;
using EventManagementSystem.Infrastructure.Services;
using EventManagementSystem.Infrastructure.Services.EmailNotification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services
    builder.Services.AddControllers();

    // Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "API V1", Version = "v1" });

        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[]{}
            }
        });

        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EventManagementSystem.API.xml"));
    });

    // DbContext
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Repositories
    builder.Services.AddScoped<IClientRepository, ClientRepository>();
    builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
    builder.Services.AddScoped<IEventRepository, EventRepository>();
    builder.Services.AddScoped<ITicketRepository, TicketRepository>();

    // Automapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Services
    builder.Services.AddScoped<IClientService, ClientService>();
    builder.Services.AddScoped<IProducerService, ProducerService>();
    builder.Services.AddScoped<IEventService, EventService>();
    builder.Services.AddScoped<ITicketService, TicketService>();
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<ITokenService, TokenService>();

    // Email
    builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();
    builder.Services.AddSingleton<EmailNotificationQueue>();
    builder.Services.AddSingleton<IEmailNotificationQueue>(sp => sp.GetRequiredService<EmailNotificationQueue>());

    // Background Service
    builder.Services.AddHostedService<EmailBackgroundService>();

    // Identity + JWT
    builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 12;
    }).AddEntityFrameworkStores<DataContext>();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
        options.DefaultForbidScheme =
        options.DefaultSignInScheme =
        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])),
            RoleClaimType = ClaimTypes.Role
        };
    });

    var app = builder.Build();

    // **Run EF Core migrations on startup**
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        context.Database.Migrate(); // ensures tables exist
    }

    // Middleware
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventManagementSystem API");
        options.RoutePrefix = string.Empty;
    });

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    // Logs exact startup error to Azure stdout / Log Stream
    Console.WriteLine("Startup error: " + ex.Message);
    Console.WriteLine(ex.StackTrace);
    throw;
}
