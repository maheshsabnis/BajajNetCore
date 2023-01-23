using CORE_API.MOdels;

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
    //public interface IDataService<TEntity, in TPk> where TEntity : class
    //{
    //    Task<IEnumerable<TEntity>> GetAsync();
    //    Task<TEntity> GetAsync(TPk id);
    //    Task<TEntity> CreateAsync(TEntity entity);
    //    Task<TEntity> UpdateAsync(TPk id, TEntity entity);
    //    Task<TEntity> DeleteAsync(TPk id);
    //}

    /// THe TEntity will alws be of the type EntityBase
    public interface IDataService<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<TEntity> DeleteAsync(TPk id);
    }

    /// <summary>
    /// THe Repository Interface with the ResponseObject
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface INewDataService<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<ResponseObject<TEntity>> GetAsync();
        Task<ResponseObject<TEntity>> GetAsync(TPk id);
        Task<ResponseObject<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> UpdateAsync(TPk id, TEntity entity);
        Task<ResponseObject<TEntity>> DeleteAsync(TPk id);
    }
}
