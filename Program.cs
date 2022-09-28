using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using VisitorManagementStudent2022.Data;
using VisitorManagementStudent2022.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITextFileOperations, TextFileOperations>();

builder.Services.AddSingleton<SweetAlert>();
builder.Services.AddSingleton<ISweetAlert, SweetAlert>(implementationFactory: x => x.GetRequiredService<SweetAlert>());
builder.Services.AddSingleton<ISweetAlert2, SweetAlert>(x => x.GetRequiredService<SweetAlert>());
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IDBCalls, DBCalls>();
builder.Services.AddSingleton<IAPI, API>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
