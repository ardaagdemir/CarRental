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
    public class RentalManager : IRentalService
    {
        //Global variable
        private IRentalDal _rentalDal;

        //Constructor
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //BusinessCode
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByBrandId(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentalId == rentalId));
        }

        public IResult Add(Rental rental) //Messages will change
        {
            if (CheckReturnStatus(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarAdded);
            }

            return new ErrorResult(Messages.CarDeleted);
        }


        public IResult Delete(Rental rental) //Messages will change
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Rental rental) //Messages will change
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.CarUpdated);
        }


        //
        private bool CheckReturnStatus(int carId)
            {
                var rental = _rentalDal.Get(f => f.CarId == carId);
                if (rental != null && rental.ReturnDate == null)
                {
                    return false;
                }

                return true;
            }
    }
}
