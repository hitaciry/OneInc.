using OneInc.Server.Hubs;
using OneInc.Server.Model;
using OneInc.Server.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DelayRange>(builder.Configuration.GetSection(nameof(DelayRange)));
var UIOrigin = builder.Configuration.GetValue<string>("UIOrigin") ?? "https://localhost:5173";
// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddTransient<IDelayService, DelayService>();
builder.Services.AddTransient<IStringConvertService<string>, StringConvertToBase64Service>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            //TODO: set origin from configuration
            policy.WithOrigins(UIOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();
app.MapHub<StringConverterHub>("/hub");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<StringConverterHub>("/hub");
//});

app.Run();