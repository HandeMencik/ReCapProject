using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Results;
using DataAccess.Abstact;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            bool carRentalStatus=!(_rentalDal.GetAll(r=>r.CarId==rental.CarId && r.ReturnDate==null).Any());

            if (carRentalStatus==false)
            {
                return new ErrorResult(Messages.CarIsNotRentalStatus);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.ProductAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
