using Dependency_Injection.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dependency_Injection
{
    public class Example
    {
        //Biz buradaki yapılanmayı mimaride manuel olarak kullanmıyoruz. Bunu startupda parametre olarak yedirmişler.
        //Bizim ConfigureService içerisinde service. verdiğimiz tüm değerler ilgili mimaride oluşturulacak.
        public Example()
        {
            IServiceCollection services = new ServiceCollection(); //built-in dediğimiz IoC mekanizmamız. 
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(5)));  
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

            ServiceProvider provider = services.BuildServiceProvider();    //Bu artık bize somut container/provider ımız. Artık bunun içinde yukarıdaki nesneler var.
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();



        }



    }
}
