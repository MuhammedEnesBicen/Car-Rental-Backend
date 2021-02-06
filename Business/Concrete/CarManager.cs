using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
   
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }
        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();

        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _iCarDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _iCarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _iCarDal.GetAll(p => p.ColorId == id);
        }
    }
}
