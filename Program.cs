using FootballBlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;  // <--- OBAVEZNO za Swagger

var builder = WebApplication.CreateBuilder(args);

// Razor + Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// REST API
builder.Services.AddControllers(); // ovo dodaje podršku za REST

// DbContext - SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

//builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:3049/") // tvoj IIS Express port
});


// REST API + Swagger
builder.Services.AddEndpointsApiExplorer();  // Omogućava Swagger-u da vidi API
builder.Services.AddSwaggerGen();            // Dodaje Swagger generator
                                             // Dodaje Swagger generator

var app = builder.Build();

// Swagger - samo u Development okruženju
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballBlazor API V1");
        c.RoutePrefix = "swagger"; // URL: /swagger
    });
}


// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();
app.UseRouting();

// REST endpoints
app.MapControllers();

// Blazor
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
