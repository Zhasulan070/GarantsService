using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("segments")]
    public class SegmentModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("name_kz")] public string NameKz { get; set; }
        [Column("active")] public bool Active { get; set; }
        [Column("codeName")] public string CodeName { get; set; }
        
    }
}