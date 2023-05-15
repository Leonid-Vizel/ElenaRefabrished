using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Data.UnitOfWork;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using FRDZSchool.Utility;
using FRDZSchool.Models.DatabaseModels;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ScheduleInfo info = new ScheduleInfo()
{
    YearDuration1 = 33,
    YearDuration2_8 = 34,
    YearDuration9 = 34,
    YearDuration10 = 34,
    YearDuration11 = 34,

    Holiday1Start = DateTime.Parse("29.10.2022"),
    Holiday1End = DateTime.Parse("06.11.2022"),
    Holiday2Start = DateTime.Parse("28.12.2022"),
    Holiday2End = DateTime.Parse("08.01.2023"),
    Holiday3Start = DateTime.Parse("25.03.2023"),
    Holiday3End = DateTime.Parse("02.04.2023"),
    Holiday4Start = DateTime.Parse("20.02.2023"),
    Holiday4End = DateTime.Parse("26.02.2023"),

    Quarter1Start = DateTime.Parse("01.09.2022"),
    Quarter1End = DateTime.Parse("28.10.2022"),
    Quarter2Start = DateTime.Parse("07.11.2022"),
    Quarter2End = DateTime.Parse("27.12.2022"),
    Quarter3Start = DateTime.Parse("09.01.2023"),
    Quarter3End = DateTime.Parse("24.03.2023"),
    Quarter4Start = DateTime.Parse("03.04.2023"),
    Quarter4End = DateTime.Parse("31.05.2022")
};

builder.Services.AddSingleton<ScheduleInfo>(info);

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

app.UseRequestLocalization();

CultureInfo cultureInfo = new CultureInfo("ru-RU", true);
cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

#region Configure schedule
IServiceScope scope = app.Services.CreateScope();
ApplicationContext db = scope.ServiceProvider.GetService<ApplicationContext>();

foreach (PropertyInfo propInfo in info.GetType().GetProperties())
{
    SettingOption? option = db.Settings.FirstOrDefault(x => x.Name.Equals(propInfo.Name));
    if (option == null)
    {
        option = new SettingOption()
        {
            Name = propInfo.Name,
            Value = propInfo.GetValue(info).ToString()
        };
        db.Settings.Add(option);
    }
    else
    {
        Type intType = typeof(int);
        switch (propInfo.PropertyType.ToString())
        {
            case "System.Int32":
                if (int.TryParse(option.Value, out int parseResult))
                {
                    propInfo.SetValue(info, parseResult);
                }
                else
                {
                    propInfo.SetValue(info, 0);
                    option.Value = "0";
                    db.Settings.Update(option);
                }
                break;
            case "System.DateTime":
                if (DateTime.TryParse(option.Value, out DateTime dateParseResult))
                {
                    propInfo.SetValue(info, dateParseResult);
                }
                else
                {
                    propInfo.SetValue(info, DateTime.Now);
                    option.Value = DateTime.Now.ToString();
                    db.Settings.Update(option);
                }
                break;
        }
    }
}
#endregion

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
