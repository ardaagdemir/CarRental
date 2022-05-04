using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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

        public List<Color> GetAll()
        {
            return _colorManager.GetAll();
        }

        public List<Color> GetByColorId(int colorId)
        {
            return _colorManager.GetAll(c => c.ColorId == colorId);
        }
    }
}
