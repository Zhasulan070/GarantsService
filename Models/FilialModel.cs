using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("filials")]
    public class FilialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("name_kz")] public string NameKz { get; set; }
        [Column("active")] public bool Active { get; set; }
        [Column("regionId")] public int RegionId { get; set; }
        [Column("filialCode")] public string FilialCode { get; set; }
        [Column("isNeedControl")] public bool IsNeedControl { get; set; }
    }
}