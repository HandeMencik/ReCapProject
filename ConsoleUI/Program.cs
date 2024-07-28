// See https://aka.ms/new-console-template for more information

using Bussines.Concrete;
using DataAccess.Concrete.InMemory;

CarManager carManager = new CarManager(new InMemoryCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}