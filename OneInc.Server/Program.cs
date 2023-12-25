using OneInc.Server.Hubs;
using OneInc.Server.Model;
using OneInc.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DelayRange>(builder.Configuration.GetSection(nameof(DelayRange)));
builder.Services.AddTransient<IDelayService, DelayService>();
builder.Services.AddTransient<IStringConvertService<string>, StringConvertToBase64Service>();
builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapFallbackToFile("/index.html");

app.MapHub<StringConverterHub>("/stringConverterHub");

app.Run();
