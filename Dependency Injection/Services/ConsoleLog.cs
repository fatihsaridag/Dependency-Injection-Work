using Dependency_Injection.Services.Interfaces;
using System;

namespace Dependency_Injection.Services
{
    public class ConsoleLog : ILog
    {

        public ConsoleLog(int a)
        {

        }

        public void Log()
        {
            Console.WriteLine("Console loglama işlemi gerçekleştirildi...");
        }
    }
}
