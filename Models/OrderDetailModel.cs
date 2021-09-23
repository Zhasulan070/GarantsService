using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("order_detail")]
    public class OrderDetailModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]  public int Id { get; set; }
        [Column("orderId")]  public int OrderId { get; set; }
        [Column("summ")] public double Summ { get; set; }
        [Column("currencyId")] public int CurrencyId { get; set; }
        [Column("mounth")] public int Mounth { get; set; }
        [Column("kl")] public string KlNumber { get; set; }
    }
}