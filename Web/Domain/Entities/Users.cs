using System.ComponentModel.DataAnnotations;

namespace Web.Domain.Entities
{
  public class Users
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }
  }
}