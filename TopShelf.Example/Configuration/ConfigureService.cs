using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf.Example.Configuration
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MyService>(service =>
                {
                    //Acá se setea el servicio que corremos
                    service.ConstructUsing(s => new MyService());
                    //Acá se detalla que metodo va a correr cuando inicializa
                    service.WhenStarted(s => s.Start());
                    //Acá se detalla que metodo va a correr cuando se detiene
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                //Los siguientes son datos declarativos del servicio, como el nombre y la descripción
                configure.SetServiceName("EjemploTopShelf");
                configure.SetDisplayName("EjemploTopShelf");
                configure.SetDescription("Servicio de ejemplo de TopShelf");
            });
        }
    }
}
