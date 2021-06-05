using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<List<Rental>> GetRentalsByCarId(int id);

        IDataResult<List<Rental>> GetRentalsByCustomerId(int id);

        IDataResult<List<Rental>> GetByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetByReturnDate(DateTime returnDate);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult DeleteByCarId(int carId);
    }
}
