using System.Data;
using System.Linq.Expressions;
using Biogenom.Model.Entity;
using Biogenom.Repository.Repositories;
using Biogenum.SqlServer.DbContext;

namespace Biogenum.SqlServer.Repositories;

public class UserNutrientLogRepository(
    BiogenomDbContext context) : IUserNutrientLogRepository
{
    protected readonly BiogenomDbContext Context = context;

    public IQueryable<UserNutrientLog> CustomWhere(Expression<Func<UserNutrientLog, bool>> predicate) =>
        Context.UserNutrientLogs.Where(predicate);
}