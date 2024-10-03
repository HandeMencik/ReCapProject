using Bussines.Abstract;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Bussines.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {


            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult();

        }
        public IResult Update(Car car)
        {




            _carDal.Update(car);
            return new SuccessResult();
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            // iş kodları

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }



        IDataResult<Car> ICarService.GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == id));
        }

        IDataResult<Car> ICarService.GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }
    }
}
