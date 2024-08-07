using Bussines.Abstract;
using DataAccess.Abstact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class CarManager : ICarSevice
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            // iş kodları

            return _carDal.GetAll();

        }

        public List<Car> GetCarsByBrandId(int ıd)
        {
            return _carDal.GetAll(p=>p.BrandId==ıd);
        }

        public List<Car> GetCarsByColorId(int ıd)
        {
            return _carDal.GetAll(p => p.ColorId == ıd);
        }
    }
}
