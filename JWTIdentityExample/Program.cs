using JWTIdentityExample.Contexts;
using JWTIdentityExample.Extensions;
using JWTIdentityExample.Services;
using JWTIdentityExample.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddIdentityExtension();
//builder.Services.AddConfigureApplicationCookieExtension();
//builder.Services.AddSession();
builder.Services.AddAddAuthenticationExtension(builder.Configuration);
builder.Services.AddAuthorizationExtension();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDocExtension();
    swagger.AddSecurityDefinitionExtension();
    swagger.AddSecurityRequirementExtension();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.SeedIdentityDataAsync().Wait();

app.MapControllers();

app.Run();