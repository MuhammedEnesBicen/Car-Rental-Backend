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
            //Data Transformation Object
            //CarTest();
            //IoC 
            //BrandTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental {  CarId = 4, CustomerId = 2, RentDate = DateTime.Now}) ;
            var result = rentalManager.GetRentalDetails();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName+"\t"+item.CustomerName);
            }

        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName.Trim() + "/" + car.BrandName.Trim() + "/" + car.ColorName.Trim() + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void LoadingImageForACar()
        {
            Console.WriteLine("Please enter the car id");
            int carId = Convert.ToInt32(Console.ReadLine());

        }
    }
}
