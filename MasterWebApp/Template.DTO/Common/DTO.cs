namespace Template.DTO
{
    public abstract class DTO<T> : BaseDTO, IDTO<T>
    {
        public virtual T Id { get; set; }
    }
}
