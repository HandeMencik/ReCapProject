using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal :EfEntityRepositoryBase<Entities.Concrete.Color,ReCapContext>,IColorDal
    {

    }
}
