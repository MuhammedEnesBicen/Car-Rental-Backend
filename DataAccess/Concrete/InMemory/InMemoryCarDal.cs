using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=new DateTime(2020),DailyPrice=200000,Description="S90"},
            new Car{CarId=2,BrandId=1,ColorId=3,ModelYear=new DateTime(2015),DailyPrice=100000,Description="s60"},
            new Car{CarId=3,BrandId=2,ColorId=2,ModelYear=new DateTime(2000),DailyPrice=20000,Description="Passat"},
            new Car{CarId=4,BrandId=2,ColorId=3,ModelYear=new DateTime(2019),DailyPrice=170000,Description="Transporter"},
            new Car{CarId=5,BrandId=3,ColorId=1,ModelYear=new DateTime(2021),DailyPrice=300000,Description="c3"}
            };


        }
        public void Add(Car car)
        {
            bool isExist = _cars.Exists(c=> c.CarId==car.CarId);
            if (isExist)
            {
                Console.WriteLine("There is a car who has this carId\t"+car.Description+" is not added");
            }
            else
            {
                _cars.Add(car);
            }
            
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
