using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly DatabaseSettings _databaseSettingsOptions;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<DatabaseSettings> settings) : base(options)
        {
            _databaseSettingsOptions = settings.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies(_databaseSettingsOptions.UseLazyLoading)
                    .UseSqlServer(_databaseSettingsOptions.ApplicationConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public IQueryable<TEntity> ExecuteSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            return Set<TEntity>().FromSqlRaw(sql, parameters).AsTracking(QueryTrackingBehavior.NoTracking);
        }
        public virtual int ExecuteSqlCommand(string sql, bool disableTransaction = false, params object[] parameters)
        {
            var previousTimeOut = Database.GetCommandTimeout();

            Database.SetCommandTimeout(_databaseSettingsOptions.CommandTimeOutInSecond);

            int result = 0;

            using (var transaction = disableTransaction ? null : Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {

                    result = Database.ExecuteSqlRaw(sql, parameters);

                    if (transaction is not null)
                        transaction.Commit();
                }
                catch (Exception)
                {
                    if (transaction is not null)
                        transaction.Rollback();

                    throw;
                }
                finally
                {
                    Database.SetCommandTimeout(previousTimeOut);
                }

            }

            return result;
        }
    }
}
