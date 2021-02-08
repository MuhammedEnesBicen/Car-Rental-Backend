using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
            Car a = new Car { CarId = 7, BrandId = 1, ColorId = 1, ModelYear = new DateTime(2020,12,12), DailyPrice = 200000, Description = "Qashqai" };
            inMemoryCarDal.Add(a );

            EfCarDal efCarDal = new EfCarDal();
            
            //efCarDal.Add(a); is added
            CarManager carManager = new CarManager(efCarDal);
            
            
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
            
        }
    }
}
