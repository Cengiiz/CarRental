using CarRentalCore.Data;
using CarRentalCore.Repositories;
using CarRentalService.Mapping;
using CarRentalService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRental API", Version = "v1" });
});

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IVehicleLogService, VehicleLogService>();



//builder.Services.AddScoped<IMapper<Role, RoleDto>, RoleMapper>();
//builder.Services.AddScoped<IMapper<User, UserDto>, UserMapper>();
//builder.Services.AddScoped<IMapper<Vehicle, VehicleDto>, VehicleMapper>();
//builder.Services.AddScoped<IMapper<VehicleLog, VehicleLogDto>, VehicleLogMapper>();

builder.Services.AddControllers();
//    .addjsonoptions(options =>
//{
//    options.jsonserializeroptions.referencehandler = system.text.json.serialization.referencehandler.preserve;
//});

builder.Services.AddAutoMapper(typeof(AutoMapping));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    SeedData.Initialize(services, context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRental API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
