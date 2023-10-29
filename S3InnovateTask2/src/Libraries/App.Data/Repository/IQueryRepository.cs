using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public interface IQueryRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        IQueryable<TEntity> ExecuteSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
        int ExecuteSqlCommand(string sql, bool disableTransaction = false, params object[] parameters);
    }
}
