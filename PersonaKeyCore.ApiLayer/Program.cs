using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonaKeyCore.DataAccessLayer.Concrete.Context;
using PersonaKeyCore.EntityLayer.Concrete;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.BusinessLogicLayer.Services.Concrete;
using PersonaKeyCore.DataAccessLayer.Repository.Abstract;
using PersonaKeyCore.DataAccessLayer.Repository.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace PersonaKeyCore.ApiLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Veritabaný baðlantýsýný ve Identity'yi ekle
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Servisleri DI konteynerine kaydetme
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            // Business Logic Layer servislerini kaydetme
            builder.Services.AddScoped<IAccessLogService, AccessLogManager>();
            builder.Services.AddScoped<IAppRoleService, AppRoleManager>();
            builder.Services.AddScoped<IAppUserService, AppUserManager>();
            builder.Services.AddScoped<ICardService, CardManager>();
            builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
            builder.Services.AddScoped<IDeviceService, DeviceManager>();
            builder.Services.AddScoped<IDoorService, DoorManager>();
            builder.Services.AddScoped<IPermissionService, PermissionManager>();
            builder.Services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
            builder.Services.AddScoped<IRoleService, RoleManager>();
            builder.Services.AddScoped<IPersonService, PersonManager>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}