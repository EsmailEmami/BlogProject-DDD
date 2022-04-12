using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Data.Repository;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery;

        // modify the IQueryable using the specification's criteria expression
        query = query.Where(specification.Criteria);

        // Includes all expression-based includes
        query = specification.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        // Include any string-based include statements
        query = specification.IncludeStrings.Aggregate(query,
            (current, include) => current.Include(include));

        // Apply ordering if expressions are set
        query = query.OrderBy(specification.OrderBy);

        query = query.GroupBy(specification.GroupBy).SelectMany(x => x);

        // Apply paging if enabled
        if (specification.IsPagingEnabled)
        {
            query = query.Skip(specification.Skip)
                .Take(specification.Take);
        }
        return query;
    }
}