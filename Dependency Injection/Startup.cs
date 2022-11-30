using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_Injection
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
          // Bir container var ve bu containera biz nasýl nesne dahil ettiðimizi gördük.
        /*  services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog(5)));*/       //Bu davranýþ default olarak singletendýr.
            /*  services.Add(new ServiceDescriptor(typeof(TextLog),new TextLog(),ServiceLifetime.Transient);         */    //Biz bunun transient olarak davranýþ almasýný istedik.

            // Tek bir nesneyi tüm isteklere gönderir.
            // services.AddSingleton<ConsoleLog>();    //new T();
            /* services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5)); */ // new T();   Constructor parametre alýyor ise 


            //Tüm isteklerde ayrý bir tane bu nesneden oluþturacak ve her bir isteðin talebine bu nesneden göndericek.
            //services.AddScoped<ConsoleLog>();
            //services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));


            //Her isteðin her talebine özel nesne üreticek ve göndericek.
            //services.AddTransient<ConsoleLog>();
            //services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));

            /* services.AddScoped<ILog>(p => new ConsoleLog(5)); */  //Bu þekilde bir kullaným yapýlabilir yani ConsoleLogu kullanabiliriz.
                                                                     //Gün geldi ihtiyacýmýz deðiþti ve artýk textlogu da kullanabilriz



            services.AddScoped<ILog, TextLog>();    //Containera ILog türünde bir nesne koy , ama bu nesne TextLog olsun.





            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
