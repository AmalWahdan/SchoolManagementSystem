using App.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Services;
using System.Text.Json.Serialization;

namespace SchoolSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<SchoolDB>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                }
                );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<SchoolDB>()
                        .AddDefaultTokenProviders();

            //Prevent infinite loop
            builder.Services.AddControllers().AddJsonOptions(x =>
               x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<UserManager<ApplicationUser>>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });


            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;

            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<ILevelService, LevelService>();
            builder.Services.AddScoped<IHolidayService, HolidayService>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();
            builder.Services.AddScoped<IClassService, ClassService>();

            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IlevelRepository, levelRepository>();
            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers().AddJsonOptions(x =>
              x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");

            app.Run();
        }
    }
}