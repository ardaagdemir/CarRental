using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager :IUserService
    {
        //Global variable
        private IUserDal _userDal;
        //Constructor
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //BusinessCode
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<List<User>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == userId), Messages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdeted);
        }
    }
}
