using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ApplicationQueryRepository : IQueryRepository
    {
        private readonly IApplicationDbContext _context;

        public ApplicationQueryRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().AsTracking(QueryTrackingBehavior.NoTracking);
        }

        public IQueryable<TEntity> ExecuteSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return _context.ExecuteSql<TEntity>(sql, parameters);
        }

        public int ExecuteSqlCommand(string sql, bool disableTransaction = false, params object[] parameters)
        {
            return _context.ExecuteSqlCommand(sql, disableTransaction, parameters);
        }


    }
}
