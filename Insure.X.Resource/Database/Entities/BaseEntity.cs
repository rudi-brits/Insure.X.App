using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
