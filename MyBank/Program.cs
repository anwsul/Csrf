var builder = WebApplication.CreateBuilder();

builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();

app.MapRazorPages();
app.MapPost("/logout", (HttpContext context) => context.Session.Remove);

app.Run();
