using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        IImageDal _imageDal;
        public CarManager(ICarDal iCarDal, IImageDal imageDal)
        {
            _iCarDal = iCarDal;
            _imageDal = imageDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            

            //bussiness kodları buraya yazılır
            _iCarDal.Add(car);
            Image image = new Image { CarId = car.CarId, ImagePath = car.Thumbnail, LoadDate = DateTime.Now };
            _imageDal.Add(image);
            

            return new SuccessResult(Messages.CarAdded);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
           
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.CarsListed);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_iCarDal.Get(c => c.CarId == carId));
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult("Car had deleted, successfuly");
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            Image image= _imageDal.Get(i => i.CarId == car.CarId);
            if(image!=null)
            image.ImagePath = car.Thumbnail;
            _imageDal.Update(image);
            return new SuccessResult("Car had updated successfuly");
        }

        public IResult DeleteById(int carId)
        {
            Car temp =_iCarDal.Get(c => c.CarId ==carId);
            if (temp!=null)
            {
                _iCarDal.Delete(temp);
                
            }
            return new SuccessResult("Car had deleted successfuly");
        }
    }
}
