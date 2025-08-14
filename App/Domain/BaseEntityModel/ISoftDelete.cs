namespace Domain.BaseEntityModel
{
    public interface ISoftDelete
    {
        bool Deleted { get; set; }
    }
}
