using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Genel bağımlılıkları yüklemek için yazılır
        void Load(IServiceCollection serviceCollection);
    }
}
