using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.BaseEntityModel;

namespace Domain.Entities
{
    public class User : BaseEntity<int>
    {        

        [Column("username")]
        [StringLength(24)]
        public string Username { get; set; } = null!;

        [Column("userpassword")]
        [StringLength(200)]
        public string Userpassword { get; set; } = null!;

        [Column("fullname")]
        [StringLength(200)]
        public string? Fullname { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string? Description { get; set; }      

    }
}
