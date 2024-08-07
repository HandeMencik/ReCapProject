// See https://aka.ms/new-console-template for more information

using Bussines.Concrete;
using DataAccess.Concrete.EntityFramework;


CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetCarsByColorId(1))
{
    Console.WriteLine(car.DailyPrice);
}