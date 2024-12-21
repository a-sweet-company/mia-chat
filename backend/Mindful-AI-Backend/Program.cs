using GeminiController.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<AIController>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
    options.ListenLocalhost(7013, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
        listenOptions.UseHttps();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // URL do frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");
Console.WriteLine("CORS configurado: AllowAll");
app.UseCors("AllowFrontend");
app.UseCors("AllowSpecificOrigins");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
// Servir arquivos estáticos (frontend)
app.UseDefaultFiles();
app.UseStaticFiles();

// Middleware para redirecionar para o index.html
app.Use(async (context, next) =>
{
    if (!context.Request.Path.Value.StartsWith("/api") &&
        !System.IO.File.Exists($"wwwroot{context.Request.Path}"))
    {
        context.Request.Path = "/index.html";
    }
    await next();
});

app.MapControllers();

app.Run();
