using Mercado.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            CriandoUsuario();
            ListarUsuario();
        }

        public static void ListarUsuario()
        {
            using (var repo = new MercadoContext())
            {
                IList<User> User = repo.User.ToList();
                foreach(User item in User)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public static void CriandoUsuario()
        {
            User p = new User();
            p.email = "admin@admin.com";
            p.password = "abc12345";
            p.Name = "admin";

            using (var contexto = new MercadoContext())
            {
                contexto.User.Add(p);
                contexto.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
