using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //Operasyonların sınıfları IDataResult ve IResult'a göre belirlenmelidir.
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetByBrandId(int brandId);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
