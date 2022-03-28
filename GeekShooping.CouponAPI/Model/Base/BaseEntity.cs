using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.CouponAPI.Model.Base;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    
    [Column("id")]
    public Guid Id { get; set; }
}
