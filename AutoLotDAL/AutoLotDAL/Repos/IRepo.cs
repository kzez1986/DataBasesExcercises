﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Repos
{
    interface IRepo<T>
    {
        int Add(T entity);
        Task<int> AddAsync(T entity);
        int AddRange(IList<T> entities);
        Task<int> AddRangeAsync(IList<T> entities);
        int Save(T entity);
        Task<int> SaveAsync(T entity);
        int Delete(int id, byte[] timeStamp);
        Task<int> DeleteAsync(int id, byte[] timestamp);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        T GetOne(int? id);
        Task<T> GetOneAsync(int? id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        List<T> ExecuteQuery(string sql);
        Task<List<T>> ExecuteQueryAsync(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
        Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects);

    }
}
