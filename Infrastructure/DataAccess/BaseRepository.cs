﻿using Infrastructure.DataAccess.Interface;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.DataAccesLayer

{
    /// <summary>
    /// Abstrack ile işaretlememizin amacı diğer sınıflara kalıtım yolu ile aktarmak.
    /// Amacımız nesne yaratmak değil.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public abstract class BaseRepository<TEntity, TId, TContext> : IRepository<TEntity, TId>
          where TEntity : BaseEntity<TId>
        where TContext : DbContext, new()
    {
        /// <summary>
        /// BaseRepostry ile kalıtım verilerek bütün Controllerlere kritere uyan kayıtları çektik   
        /// eğer kriter vermezsek bütün kayıtları çekiyor
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="navProp"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] navProp)

        {

            using TContext ctx = new();

            IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

            if (predicate != null)


            {
                //Expression<Func<TEntity, bool>>
                dbSet = dbSet.Where(predicate);
            }

            if (navProp == null)
                return await dbSet.ToListAsync();
            else
            {
                foreach (var item in navProp)
                {
                    dbSet = dbSet.Include(item);
                }
                return await dbSet.ToListAsync();
            }
        }


        /// <summary>
        /// Bu Method kritere uyan tek kayıt dönüyor. Dışarıdan kriter alıyor ve kriter zorunlu
        /// </summary> Id sini generic yaptık.
        /// <param name="predicate"></param>
        /// <param name="navProp"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] navProp)

        {

            using TContext ctx = new();

            IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

            if (navProp != null)
            {
                foreach (var item in navProp)
                {
                    dbSet = dbSet.Include(item);
                }
            }


            //Expression<Func<TEntity, bool>>
            return await dbSet.SingleOrDefaultAsync(predicate);

        }
        /// <summary>
        /// Id ye göre kriter çekiyoruz.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="navProp"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(TId id, params string[] navProp)
        {
            using TContext ctx = new();

            IQueryable<TEntity> dbSet = ctx.Set<TEntity>();


            if (navProp == null)

                return await dbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));

            else
            {
                IQueryable<TEntity> set = dbSet;

                foreach (var item in navProp)
                {
                    dbSet = dbSet.Include(item);
                }

                //Aşağıdaki Cast include edilemiyor bakılacak
                return await dbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));

            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using TContext ctx = new();
            await ctx.Set<TEntity>().AddAsync(entity);
            await ctx.SaveChangesAsync();
            return entity;
        }


        public async Task UpdateAsync(TEntity entity)
        {
            using TContext ctx = new();
            ctx.Set<TEntity>().Update(entity);
            await ctx.SaveChangesAsync();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            using TContext ctx = new();
            ctx.Set<TEntity>().Remove(entity);
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            using TContext ctx = new();
            ctx.Set<TEntity>().Remove(await GetByIdAsync(id));
            await ctx.SaveChangesAsync();
        }
    }
}
