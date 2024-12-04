using CarRentalMVC;
using CarRentalMVC.Services;
using CarRentalMVC.Services.Home;
using CarRentalMVC.Services.Menu;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<RestClient>(new RestClient(builder.Configuration.GetValue<string>("ApiBaseUrl")));

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IVehicleLogService, VehicleLogService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IMenuService, MenuService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
SessionManager.Initialize(app.Services.GetRequiredService<IHttpContextAccessor>());
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginLoad}");

app.Run();
