using Biogenom.Repository.Repositories;

namespace Biogenom.Repository.UnitOfWork;

public interface IUnitOfWork
{
    IUserNutrientLogRepository UserNutrientLogRepository { get; }

    int Commit();

    Task<int> CommitAsync();

    void BeginTransaction();
    void RollbackTransaction();
    void CommitTransaction();
}