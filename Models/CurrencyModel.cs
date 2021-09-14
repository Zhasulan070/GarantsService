using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("currencies")]
    public class CurrencyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("code")] public string Code { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("name_kz")] public string NameKz { get; set; }
        [Column("active")] public bool Active { get; set; }
    }
}