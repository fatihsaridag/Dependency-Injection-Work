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
          // Bir container var ve bu containera biz nas�l nesne dahil etti�imizi g�rd�k.
        /*  services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog(5)));*/       //Bu davran�� default olarak singletend�r.
            /*  services.Add(new ServiceDescriptor(typeof(TextLog),new TextLog(),ServiceLifetime.Transient);         */    //Biz bunun transient olarak davran�� almas�n� istedik.

            // Tek bir nesneyi t�m isteklere g�nderir.
            // services.AddSingleton<ConsoleLog>();    //new T();
            /* services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5)); */ // new T();   Constructor parametre al�yor ise 


            //T�m isteklerde ayr� bir tane bu nesneden olu�turacak ve her bir iste�in talebine bu nesneden g�ndericek.
            //services.AddScoped<ConsoleLog>();
            //services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));


            //Her iste�in her talebine �zel nesne �reticek ve g�ndericek.
            //services.AddTransient<ConsoleLog>();
            //services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));

            /* services.AddScoped<ILog>(p => new ConsoleLog(5)); */  //Bu �ekilde bir kullan�m yap�labilir yani ConsoleLogu kullanabiliriz.
                                                                     //G�n geldi ihtiyac�m�z de�i�ti ve art�k textlogu da kullanabilriz



            services.AddScoped<ILog, TextLog>();    //Containera ILog t�r�nde bir nesne koy , ama bu nesne TextLog olsun.





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
