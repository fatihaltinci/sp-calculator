using NToastNotify;
using Python.Runtime;
using SPCalculator.Data.Extensions;
using SPCalculator.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Proje ayaða kalkarken servislere bakarak kalkar. 
builder.Services.LoadDataExtensions(builder.Configuration); // LoadDataExtensions methodunu çaðýrdýk.
builder.Services.LoadServiceExtensions(); // LoadServiceExtensions methodunu çaðýrdýk.

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions() // Toast mesajlarýný kullanmak için
    {
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight, // Sað üstte gösterilsin
        TimeOut = 3000 // 3 saniye gösterilsin
    })
    .AddRazorRuntimeCompilation(); // Razor sayfalarý çalýþma anýnda derlensin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify(); // Toast mesajlarýný kullanmak için
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
