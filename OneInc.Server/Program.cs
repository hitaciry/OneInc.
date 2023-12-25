using OneInc.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapFallbackToFile("/index.html");

app.MapHub<StringConverterHub>("/stringConverterHub");

app.Run();
