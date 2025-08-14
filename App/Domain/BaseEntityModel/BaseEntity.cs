using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.BaseEntityModel
{
    public partial class BaseEntity<T> : IEntity
    {
        [Key]
        [Column("id")]
        public new int Id { get; set; }

        [Column("inserted_by")]
        public int? InsertedBy { get; set; }

        [Column("inserted_date", TypeName = "timestamp(6) without time zone")]
        public DateTime? InsertedDate { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }

        [Column("updated_date", TypeName = "timestamp(6) without time zone")]
        public DateTime? UpdatedDate { get; set; }

        [Column("row_status")]
        public short? RowStatus { get; set; }

        [Column("deleted")]
        public bool? Deleted { get; set; }
    }
}
