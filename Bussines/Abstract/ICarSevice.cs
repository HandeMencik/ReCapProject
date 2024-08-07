using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ICarSevice
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int ıd);
        List<Car> GetCarsByColorId(int ıd);
    }
}
