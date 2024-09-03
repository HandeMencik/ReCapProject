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
//CustomerTest();
//UserTest();
RentalManager rentalManager = new RentalManager(new EfRentalDal());
 var value = rentalManager.Add(new Rental
{
    CarId = 2,
    CustomerId = 2,
    RentDate = new DateTime(2024, 7, 2)
});
Console.WriteLine("işleminiz : " +  " " + value.Success  + " " + value.Message);











    static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    //Car Details
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(car.CarId + " " + car.CarDescription + "  " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
    }

    //Add
    Random rnd = new Random();
    int year = rnd.Next(2000, 2024);
    carManager.Add(new Car { CarDescription = "Hatasız", ColorId = 1, BrandId = 2, ModelYear = new DateTime(year, 01, 01), DailyPrice = 200000 });

    //Delete
    carManager.Delete(new Car());

    //Update
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
    //GetAll
    foreach (var c in colorManager.GetAll().Data)
    {
        Console.WriteLine(c.ColorName);
    }

    //Update
    var color = colorManager.GetById(3).Data;
    color.ColorName = "Gri";
    colorManager.Update(color);

    //Add
    color = new Color();  // Aynı değişkeni kullanıyoruz
    color.ColorName = "Mavi";
    colorManager.Add(color);

    //Delete
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

static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    customerManager.Add(new Customer { CompanyName = "Individual", UserId = 2 });
    foreach (var customer in customerManager.GetAll().Data)
    {
        Console.WriteLine(customer.CustomerId + " " + customer.CompanyName);
    }
}

static void UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Add(new User { UserName = "Buse", UserSurname = "Güleç", Email = "BuseGlc@mail.com", Password = "1a2b3c" });
    foreach (var user in userManager.GetAll().Data)
    {
        Console.WriteLine(user.UserId + " " + user.UserName + " " + user.UserSurname + " " + user.Email + " " + user.Password);

    }
}