using System.Linq.Expressions;
using Biogenom.Model.Entity;

namespace Biogenom.Repository.Repositories;

public interface IUserNutrientLogRepository
{
    IQueryable<UserNutrientLog> CustomWhere(Expression<Func<UserNutrientLog, bool>> predicate);
}