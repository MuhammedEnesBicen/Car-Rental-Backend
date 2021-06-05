using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             select new RentalDetailDto { RentalId=r.Id,carId=c.CarId,CustomerId=u.Id, CarName = c.CarName, CustomerName = u.FirstName+" "+u.LastName,DailyPrice=c.DailyPrice, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }
    }
}
