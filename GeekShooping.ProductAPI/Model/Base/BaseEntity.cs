using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.ProductAPI.Model.Base;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}
