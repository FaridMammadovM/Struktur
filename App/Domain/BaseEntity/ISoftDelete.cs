namespace Domain.BaseEntity
{
    public interface ISoftDelete
    {
        bool Deleted { get; set; }
    }
}
