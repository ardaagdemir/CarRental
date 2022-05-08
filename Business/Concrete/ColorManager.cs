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
    public class ColorManager : IColorService
    {
        private IColorDal _colorManager;

        public ColorManager(IColorDal colorDal)
        {
            _colorManager = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorManager.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorManager.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorManager.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Color>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorManager.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Color color)
        {
            _colorManager.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
