using JWTExample.Contexts;
using JWTExample.Extensions;
using JWTExample.Services;
using JWTExample.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
});
builder.Services.AddIdentityExtension();
builder.Services.AddConfigureApplicationCookieExtension();
builder.Services.AddSession();
builder.Services.AddAddAuthenticationExtension(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

await app.SeedIdentityDataAsync();

app.MapControllers();

app.Run();
