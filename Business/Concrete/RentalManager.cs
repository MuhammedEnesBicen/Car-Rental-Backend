using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(c=> c.CarId ==rental.CarId);
            if (result!=null)
            {
    
                    return new ErrorResult(Messages.RentalNotAdded);
            }
            Car car = _carDal.Get(c => c.CarId == rental.CarId);
            if (car!= null)
            {
                car.IsRented = true;
                _carDal.Update(car);
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            Car car = _carDal.Get(c => c.CarId == rental.CarId);
            if (car != null)
            {
                car.IsRented = false;
                _carDal.Update(car);
            }


            _rentalDal.Delete(rental);
            return new SuccessResult("Rental had deleted successfuly");
        }

        public IResult DeleteByCarId(int carId)
        {
            Car car = _carDal.Get(c => c.CarId == carId);
            car.IsRented = false;
            _carDal.Update(car);
            Rental rental = _rentalDal.Get(c => c.CarId == carId);
            if (rental != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult("Rental had deleted successfuly");
            }
            else
            {
                return new SuccessResult("Rental didnt find");
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=> r.RentDate == rentDate));
        }

        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == returnDate));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
        }

        public IDataResult<List<Rental>> GetRentalsByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id));
        }
    }
}
