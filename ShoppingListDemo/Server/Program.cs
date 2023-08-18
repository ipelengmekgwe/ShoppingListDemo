using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ShoppingListDemo.Server.Data;
using ShoppingListDemo.Server.Mapper;
using ShoppingListDemo.Server.Models;
using ShoppingListDemo.Server.Services;
using ShoppingListDemo.Server.Services.Interfaces;

namespace ShoppingListDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //builder.Services.AddAutoMapper(typeof(MappingProfile));

            var mappingConfig = new MapperConfiguration(x => x.AddProfile<MappingProfile>());
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>()
                .AddScoped<IShoppingItemRepository, ShoppingItemRepository>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}