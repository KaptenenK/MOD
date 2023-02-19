﻿using MOD.Database.Entities;

namespace MOD.Database.Services
{
    public interface IDbService
    {

        Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity : class
      where TDto : class;
        Task<List<TDto>> GetAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
           where TEntity : class
           where TDto : class;

        Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;

        Task<bool> SaveChangesAsync();
        Task<TEntity> AddAsync<TEntity, TDto>(TDto dto) where TEntity : class where TDto : class;

        void Update<TEntity, TDto>(int id, TDto dto) where TEntity : class, IEntity
        where TDto : class;

        Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
        public void DeleteAsync<TEntity>(TEntity dto) where TEntity : class;
        //var kommer det här ifrån?????
        string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Include<TEntity>() where TEntity : class;
    }
}