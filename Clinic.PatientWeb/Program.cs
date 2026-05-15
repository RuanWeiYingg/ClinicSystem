var builder = WebApplication.CreateBuilder(args);

// ── Services ────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// Bắt buộc phải có trước AddSession
builder.Services.AddMemoryCache();

// Kết nối API
builder.Services.AddHttpClient("ClinicAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7137/");
});

// Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Dùng Session trong Layout / Middleware
builder.Services.AddHttpContextAccessor();

// ── Pipeline ────────────────────────────────────────────────
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Session TRƯỚC Authorization
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();