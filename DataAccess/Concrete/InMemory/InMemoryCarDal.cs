using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //oracle,Sql server,mongoDb,PostGres
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1, ColorId=1, DailyPrice=600000, Description="Sahibinden Temiz seri5 ", ModelYear="2019"},
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int ıd)
        {
            //Where:içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve döndürür.
            return _cars.Where(p=>p.Id==ıd).ToList();
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün Id sine sahip olan listedeki ürünü bul ve güncelle 
            Car CarToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            CarToUpdate.Id=car.Id;
            CarToUpdate.BrandId=car.BrandId;
            CarToUpdate.ModelYear=car.ModelYear;
            CarToUpdate.Description=car.Description;
            CarToUpdate.DailyPrice=car.DailyPrice;
            CarToUpdate.ColorId=car.ColorId;

        }
    }
}
