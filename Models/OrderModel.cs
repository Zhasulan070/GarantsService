using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("applications")]
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("user_id")] public int UserId { get; set; }
        [Column("filial_id")] public int FilialId { get; set; }
        [Column("request_type_id")] public int RequestTypeId { get; set; }
        [Column("segment_id")] public int SegmentId { get; set; }
        [Column("bin")] public long Bin { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("kl")] public string Kl { get; set; }
        [Column("sum")] public double Sum { get; set; } 
        [Column("currency_id")] public int CurrencyId { get; set; } 
        [Column("valid_date")] public DateTime ValidDate { get; set; } 
        [Column("beneficator")] public string Beneficiary { get; set; } 
        [Column("create_date")] public DateTime CreateDate { get; set; } 
        [Column("status")] public bool? Status { get; set; } 
    }
}