using GeminiController.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<AIController>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // URL do frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configuração do Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;

    // HTTP
    options.ListenLocalhost(5000, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
    });

    // HTTPS
    options.ListenLocalhost(7013, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

// Middleware
app.UseCors("AllowSpecificOrigins");

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

// Redirecionar para index.html se o arquivo não existir
app.Use(async (context, next) =>
{
    if (!context.Request.Path.Value.StartsWith("/api") &&
        !System.IO.File.Exists($"wwwroot{context.Request.Path}"))
    {
        context.Request.Path = "/index.html";
    }
    await next();
});

// Mapear controllers
app.MapControllers();

app.Run();
