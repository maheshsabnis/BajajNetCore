namespace CORE_API.Services
{
    /// <summary>
    /// Generic INterface for 2 Generic Type Parameters
    /// TEntity will always be a class, the 'where' is used to apply 'constratints'
    /// on Generic Parameters
    /// TPk will always be an input parameter to a method  
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IDataService<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<TEntity> DeleteAsync(TPk id);
    }
}
