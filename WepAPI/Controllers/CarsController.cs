using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")] //Route, nasıl istekte bulunacağını gösteren kısımdır. localhost../api/cars
    [ApiController] //Attribute---Annotation(for Java), Class' ın neye bağlı olduğunu belirtmek için kullanılır.
    public class CarsController : ControllerBase
    {
        //Loosely coupled(zayıf bağımlılık = soyuta bağımlı olmak)
        //Bir somut katman diğer somut katmanın referansını tutmamalıdır.
        private ICarService _carService;

        //Constructor parametresine global değişken tanımlanmadan erişim sağlanamaz.
        //Buradaki carService parametresine program doğrudan ulaşamaz.
        
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public List<Car> Get()
        {
            //Dependency chain
            //Burada bir class'ı new' leyerek bağımlı olmamak için IoC(Inversion of Control) Container isimli bir yapıdan yararlanılması gerekmektedir.
            //IoC bizim için arka planda verilen class'ları new'ler ve buradaki bağımlılığı azaltmış olur.
            //Startup.cs' de IoC yapısı görülmektedir.
            var result = _carService.GetAll();
            return result.Data;
        }
    }
}
