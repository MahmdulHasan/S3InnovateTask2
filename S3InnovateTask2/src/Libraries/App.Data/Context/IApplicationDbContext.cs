using Microsoft.EntityFrameworkCore;


namespace App.Data.Context
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> ExecuteSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
        int ExecuteSqlCommand(string sql, bool disableTransaction = false, params object[] parameters);
    }
}
