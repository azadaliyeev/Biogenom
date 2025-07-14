using System.Data;
using Biogenom.Repository.Repositories;
using Biogenom.Repository.UnitOfWork;
using Biogenum.SqlServer.DbContext;
using Biogenum.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace Biogenum.SqlServer.UnitOfWork;

public class UnitOfWork(BiogenomDbContext context, IOptions<ConnectionStringOption> connectionString)
    : IUnitOfWork, IDisposable
{
    private readonly ConnectionStringOption _connectionStrings = connectionString.Value;
    private IDbContextTransaction? _efTransaction;
    private IUserNutrientLogRepository? _userNutrientLogRepository;

    public IUserNutrientLogRepository UserNutrientLogRepository =>
        _userNutrientLogRepository ??= new UserNutrientLogRepository(context);



    public int Commit() => context.SaveChanges();

    public Task<int> CommitAsync() => context.SaveChangesAsync();

    public void BeginTransaction() => _efTransaction ??= context.Database.BeginTransaction();

    public void RollbackTransaction() => _efTransaction?.Rollback();

    public void CommitTransaction() => _efTransaction?.Commit();

    public void Dispose() => context.Dispose();
}