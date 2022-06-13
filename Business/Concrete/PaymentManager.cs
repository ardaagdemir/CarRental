using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            var result = BusinessRules.Run(CheckIfThisCardIsAlreadySavedForThisCustomer(payment));
            if (!result.Success) return result;

            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentInformationSuccessfullySaved);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            return new SuccessDataResult<List<Payment>>(result, Messages.PaymentListed);
        }

        public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        {
            var result = _paymentDal.GetAll(p => p.CustomerId == customerId);
            return new SuccessDataResult<List<Payment>>(result, Messages.PaymentListed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            var result = _paymentDal.Get(p => p.Id == id);
            return new SuccessDataResult<Payment>(result, Messages.PaymentGeted);
        }

        public IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment)
        {
            var result = _paymentDal.Get(p => p.CustomerId == payment.CustomerId && p.CardNumber == payment.CardNumber);
            if (result != null) return new ErrorResult(Messages.ThisCardIsAlreadyRegisteredForThisCustomer);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
