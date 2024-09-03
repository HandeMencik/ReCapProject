using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //buradaki using :IDİSPOSABle PATTERN implementation of c#
            //NorthwindContext bellekten işi bitince (using bitince) atılacak
            using (TContext context = new TContext())
            {
                //git veri kaynağından benim gönderdiğim product a bir tane nesneyi eşleştir
                //(yeni ekleme olduğu eşleştirmicek sadece ekleyecek)
                //yaniii: referansı yakala
                var addedEntity = context.Entry(entity);
                //o aslında eklenecek bir nesne
                addedEntity.State = EntityState.Added;
                //onu ekle
                context.SaveChanges();



            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git veri kaynağından benim gönderdiğim product a bir tane nesneyi eşleştir                
                //yaniii: referansı yakala
                var deletedEntity = context.Entry(entity);
                //o SİLİNECEK bir nesne
                deletedEntity.State = EntityState.Deleted;
                //onu SİL
                context.SaveChanges();



            }

        }
        //tek data getiricek
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //eğer filtre göndermemişse verş kaynağından tüm datayı getir göndermişsse ona göre veriyi listele
                //veri tabanındaki bütün tabloyu listeye çevir ve bana ver 


                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();



            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //git veri kaynağından benim gönderdiğim product a bir tane nesneyi eşleştir                
                //yaniii: referansı yakala
                var updatedEntity = context.Entry(entity);
                //o güncellenecek bir nesne
                updatedEntity.State = EntityState.Modified;
                //onu güncelle
                context.SaveChanges();



            }
        }
    }
}
