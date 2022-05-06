using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<List<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Brand>> GetByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
