using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("order_files")]
    public class SaveFileModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("path")] public string Path { get; set; }
        [Column("orderId")] public string OrderId { get; set; }
    }
}