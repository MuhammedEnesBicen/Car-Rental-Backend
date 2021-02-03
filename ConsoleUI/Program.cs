using Business.Concrete;
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
            Car a = new Car { CarId = 5, BrandId = 4, ColorId = 1, ModelYear = new DateTime(2020), DailyPrice = 200000, Description = "Qashqai" };
            inMemoryCarDal.Add(a );
            CarManager carManager = new CarManager(inMemoryCarDal);
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
