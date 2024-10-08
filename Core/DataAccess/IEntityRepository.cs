﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Core.Entities;


namespace Core.DataAccess
{
    //Generic Constraint(generic Kıısıt)
    //class: referans tip olabilir demek
    //IEntity:IEntity olabilir ya da IEntity implemente eden bir nesne olabilir
    //new():new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
