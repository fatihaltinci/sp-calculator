using NToastNotify;
using Python.Runtime;
using SPCalculator.Data.Extensions;
using SPCalculator.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Proje aya�a kalkarken servislere bakarak kalkar. 
builder.Services.LoadDataExtensions(builder.Configuration); // LoadDataExtensions methodunu �a��rd�k.
builder.Services.LoadServiceExtensions(); // LoadServiceExtensions methodunu �a��rd�k.

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions() // Toast mesajlar�n� kullanmak i�in
    {
        ProgressBar = true,
        PositionClass = ToastPositions.TopRight, // Sa� �stte g�sterilsin
        TimeOut = 3000 // 3 saniye g�sterilsin
    })
    .AddRazorRuntimeCompilation(); // Razor sayfalar� �al��ma an�nda derlensin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify(); // Toast mesajlar�n� kullanmak i�in
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
