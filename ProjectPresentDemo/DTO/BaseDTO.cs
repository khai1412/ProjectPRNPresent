namespace ProjectPresentDemo.DTO
{
    public abstract class BaseDTO<TEntity> where TEntity : class
    {
        public abstract TEntity GetEntity();
        public abstract void UpdateEntity(TEntity entity);
    }
}
