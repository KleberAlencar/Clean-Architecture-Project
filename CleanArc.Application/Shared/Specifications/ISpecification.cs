namespace CleanArc.Application.Shared.Specifications;

public interface ISpecification<in TEntity>
{
    bool IsSatisfiedBy(TEntity entity);
}