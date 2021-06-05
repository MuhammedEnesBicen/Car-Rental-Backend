using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }


        //[SecuredOperation("image.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Image image)
        {
            //IResult result = BusinessRules.Run(CheckIfImageCountMoreThanFive(image.CarId));
            //if (result != null)
            //{
            //    return result;
            //}
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        private IResult CheckIfImageCountMoreThanFive(int carId)
        {
            var result = _imageDal.GetAll(p => p.CarId==carId);
            if (result.Count>5)
            {
                return new ErrorResult(Messages.CarHasFiveImages);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i=> i.CarId==carId),Messages.ImagesListed);
        }

        public IResult DElete(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IResult DeleteByCarId(int carId)
        {
            var images =_imageDal.GetAll(i => i.CarId == carId);
            foreach (var item in images)
            {
                _imageDal.Delete(item);
            }
            return new SuccessResult();
        }
    }
}
