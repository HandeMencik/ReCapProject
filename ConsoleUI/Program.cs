// See https://aka.ms/new-console-template for more information

using Bussines.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Drawing;
using Color = Entities.Concrete.Color;


//CarTest();


//ColorTest();

//BrandTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(car.CarId + " " + car.CarDescription + "  " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
    }
    Random rnd = new Random();
    int year = rnd.Next(2000, 2024);
    carManager.Add(new Car { CarDescription = "Hatasız", ColorId = 1, BrandId = 2, ModelYear = new DateTime(year, 01, 01), DailyPrice = 200000 });

    carManager.Delete(new Car());

    var value = carManager.GetById(3002).Data;
    value.CarDescription = "Hatalı";
    carManager.Update(value);

    Console.WriteLine("******************");
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(car.CarId + " " + car.CarDescription + "  " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
    }


}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var c in colorManager.GetAll().Data)
    {
        Console.WriteLine(c.ColorName);
    }

    var color = colorManager.GetById(3).Data;
    color.ColorName = "Gri";
    colorManager.Update(color);

    color = new Color();  // Aynı değişkeni kullanıyoruz
    color.ColorName = "Mavi";
    colorManager.Add(color);

    var value = colorManager.GetById(3).Data;
    colorManager.Delete(value);
    Console.WriteLine("**********************************");
    foreach (var c in colorManager.GetAll().Data)
    {
        Console.WriteLine(c.ColorName);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var b in brandManager.GetAll().Data)
    {
        Console.WriteLine(b.BrandName);
    }
    var brand = brandManager.GetById(3).Data;
    brand.BrandName = "Taycan";
    brandManager.Update(brand);



    brand = new Brand();
    brand.BrandName = "Fiat";
    brandManager.Add(brand);


    var value = brandManager.GetById(2).Data;
    brandManager.Delete(value);


    Console.WriteLine("**********************************");

    foreach (var b in brandManager.GetAll().Data)
    {
        Console.WriteLine(b.BrandName);
    }
    Console.ReadLine();
}
