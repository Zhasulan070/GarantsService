using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("order_requests")]
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]  public int Id { get; set; }
        [Column("typeId")] public int TypeId { get; set; }
        [Column("filialId")] public int FilialId { get; set; }
        [Column("segmentId")] public int SegmentId { get; set; }
        [Column("statusId")] public int StatusId { get; set; }
        [NotMapped][Column("startDateTime")] public DateTime StartDateTime { get; set; }
        [NotMapped][Column("finishDateTime")] public DateTime? FinishDateTime { get; set; }
        [Column("bin")] public string Bin { get; set; }
        [Column("companyName")] public string CompanyName { get; set; }
        [Column("kmEmail")] public string KmEmail { get; set; }
        [Column("beneficator")] public string Beneficator { get; set; }
        
        [Column("requestType")] public string RequestType { get; set; }
        [Column("filial")] public string Filial { get; set; }
        [Column("filialCode")]public string FilialCode { get; set; }
        [Column("segment")]public string Segment { get; set; }
        [Column("status")]public string Status { get; set; }
        
    }
    
    public class OrderModelWithKl
    {
        [Column("id")] public int Id { get; set; }
        [Column("order_id")] public int OrderId { get; set; }
        [Column("km_email")] public string KmEmail { get; set; }
        [Column("request_type")] public string RequestType { get; set; }
        [Column("type_id")] public int TypeId { get; set; }
        [Column("filial")] public string Filial { get; set; }
        [Column("filial_id")] public int FilialId { get; set; }
        [Column("filial_code")] public string FilialCode { get; set; }
        [Column("segment")] public string Segment { get; set; }
        [Column("segment_id")] public int SegmentId { get; set; }
        [Column("status")] public string Status { get; set; }
        [Column("status_id")] public int StatusId { get; set; }
        [Column("bin")] public string Bin { get; set; }
        [Column("company_name")] public string CompanyName { get; set; }
        [Column("beneficator")] public string Beneficator { get; set; }
        [Column("klNumber")] public string KlNumber { get; set; }
        [Column("summ")] public double Summ { get; set; }
        [Column("currency_name")] public string CurrencyName { get; set; }
        [Column("currency_id")] public int CurrencyId { get; set; }
        [Column("mounth")] public int Mounth { get; set; }
    }
    
    
    public class KlArray
    {
        public int id { get; set; }
        public int currency { get; set; }
        public string CurrencyName { get; set; }
        public string kl_type { get; set; }
        public double summa { get; set; }
        public int validDate { get; set; }
    }
    
    public class Order
    {
        public string Uin { get; set; }
        public int FilialId { get; set; }
        public string FilialName { get; set; }
        public string Filialcode { get; set; }
        public int RequestType { get; set; }
        public string RequestName { get; set; }
        public int SegmentId { get; set; }
        public string SegmentName { get; set; }
         public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Bin { get; set; }
        public string Name { get; set; }
        public List<KlArray> kl_array { get; set; }
        public string Beneficator { get; set; }
    }
}