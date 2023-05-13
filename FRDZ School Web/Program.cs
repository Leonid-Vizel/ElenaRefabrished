using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Data.UnitOfWork;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using FRDZSchool.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Accaunt/Login";
    options.LogoutPath = $"/Identity/Accaunt/Logout";
    options.AccessDeniedPath = $"/Identity/Accaunt/AccessDenied";
});

builder.Services.AddScoped<ITeacherUnitOfWork, TeacherUnitOfWork>();
builder.Services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();
builder.Services.AddScoped<IGradeUnitOfWork, GradeUnitOfWork>();
builder.Services.AddScoped<ISchoolObjectUnitOfWork, SchoolObjectUnitOfWork>();
builder.Services.AddScoped<ILessonUnitOfWork, LessonUnitOfWork>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Visitor}/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "parametrs",
//    pattern: "{controller}/{action}/{x:int}/{y:int}");

//app.MapControllerRoute(
//    name: "CatchAll",
//    pattern: "{controller=Values}/{action=Mult}/{*catchall}");

app.Run();
