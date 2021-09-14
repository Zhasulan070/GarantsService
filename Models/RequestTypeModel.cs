using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("requesttype")]
    public class RequestTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("Name")] public string Name { get; set; }
        [Column("Status")] public int Status { get; set; }
    }
}