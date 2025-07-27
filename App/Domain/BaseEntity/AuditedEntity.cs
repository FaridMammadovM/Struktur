namespace Domain.BaseEntity
{
    public interface IAudited
    {

    }

    public interface IHasInsertedTime : IAudited
    {
        public DateTime InsertedDate { get; set; }
    }

    public interface IInsertedAudited : IHasInsertedTime
    {
        int InsertedBy { get; set; }
    }

    public interface IHasUpdatedTime : IAudited
    {
        DateTime UpdatedDate { get; set; }
    }

    public interface IUpdatedAudited : IHasUpdatedTime
    {
        int UpdatedBy { get; set; }
    }

    public interface IHasDeletedTime : IAudited
    {
        DateTime DeletedDate { get; set; }
    }

    public interface IDeletedAudited : IHasDeletedTime
    {
        int DeletedBy { get; set; }
    }
}
