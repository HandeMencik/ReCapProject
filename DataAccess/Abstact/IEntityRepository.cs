using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstact
{
    //Generic constrait
                                         //Referans tip olabilir   
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {      
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        //Tek bir data getirmek için (Bankacılık sitesinde tek bir müşteriyi görüntülemek gibi 
        T Get(Expression<Func<T, bool>> filter );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
