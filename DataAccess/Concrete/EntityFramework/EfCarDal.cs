using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { CarID =c.CarId, CarName = c.CarName, BrandID=b.BrandId,
                                 BrandName = b.BrandName, ColorID=c.ColorId, ColorName = co.ColorName,
                                 DailyPrice=c.DailyPrice ,Thumbnail=c.Thumbnail,
                                 IsRented = c.IsRented, Description=c.Description,
                             ModelYear=c.ModelYear};

                return result.ToList();
            }
        }
    }
}
