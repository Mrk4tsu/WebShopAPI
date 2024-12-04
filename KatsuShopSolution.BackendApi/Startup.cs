using KatsuShopSolution.Application.Catalog.Products;
using KatsuShopSolution.Application.Common;
using KatsuShopSolution.Data.EF;
using KatsuShopSolution.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KatsuShopSolution.BackendApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KatsuShopDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

            /*
             * Dependency Injection (DI)
             * Đăng ký một dịch vụ theo phạm vi Transient, có 3 loại dịch vụ: Transient, Scoped và Singleton.
             * Transient có nghĩa là mỗi lần dịch vụ được yêu cầu, một đối tượng mới sẽ được tạo ra.
             * Scoped có nghĩa là mỗi request sẽ được tạo ra một đối tượng mới.
             * Singleton có nghĩa là chỉ tạo một đối tượng duy nhất cho mỗi ứng dụng.
             */
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<IManageProductService, ManageProductService>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger KatsuShop",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            //Sử dụng Swagger
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger KatsuShop");
            });
            //

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
