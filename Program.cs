using CurrentWeatherApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=CurrentWeather}/{action=SearchCity}/{id?}");
});

app.Run();
