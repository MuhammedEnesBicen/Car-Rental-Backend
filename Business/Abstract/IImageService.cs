using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> GetByCarId(int carId);
        IResult Add(Image image);
        IResult DElete(Image image);

        IResult DeleteByCarId(int carId);
    }
}
