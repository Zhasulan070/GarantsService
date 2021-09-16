using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("loanrequest")]
    public class LoanRequestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public int Id { get; set; }
        [Column("typeId")] public int TypeId { get; set; }
        [Column("subTypeId")] public int SubTypeId { get; set; }
        [Column("chanelId")] public int ChanelId { get; set; }
        [Column("filialId")] public int FilialId { get; set; }
        [Column("segmentId")] public int SegmentId { get; set; }
        [Column("statusId")] public int StatusId { get; set; }
        [Column("startDateTime")] public DateTime? StartDateTime { get; set; }
        [Column("finishDateTime")] public DateTime? FinishDateTime { get; set; }
        [Column("bin")] public string Bin { get; set; }
        [Column("companyName")] public string CompanyName { get; set; }
        [Column("summ")] public double Summ { get; set; }
        [Column("currencyId")] public int CurrencyId { get; set; }
        [Column("month")] public int? Month { get; set; }
        [Column("creditRate")] public double CreditRate { get; set; }
        [Column("filePath")] public string FilePath { get; set; }
        [Column("kmEmail")] public string KmEmail { get; set; }
        [Column("loanNumber")] public string LoanNumber { get; set; }
        [Column("scanDocsUrl")] public string ScanDocsUrl { get; set; }
        [Column("contractsUrl")] public string ContractsUrl { get; set; }
        [Column("contractsRemarksUrl")] public string ContractsRemarksUrl { get; set; }
        [Column("changeCategories")] public string ChangeCategories { get; set; }
        [Column("ka1Id")] public int? Ka1Id { get; set; }
        [Column("ka2Id")] public int? Ka2Id { get; set; }
        [Column("checkerId")] public string CheckerId { get; set; }
        [Column("monitoringId")] public string MonitoringId { get; set; }
        [Column("comments")] public string Comments { get; set; }
        [Column("sokl_num")] public int SoklNum { get; set; }
        [Column("sokl_num1")] public int SoklNum1 { get; set; }
        [Column("sokl_new_num")] public int SoklNewNum { get; set; }
        [Column("sokl_new_damu_num")] public int SoklNewDamuNum { get; set; }
        [Column("dz_num")] public int DzNum { get; set; }
        [Column("dz_num1")] public int DzNum1 { get; set; }
        [Column("dz_num2")] public int DzNum2 { get; set; }
        [Column("dz_num3")] public int DzNum3 { get; set; }
        [Column("dzdp_num")] public int DzdpNum { get; set; }
        [Column("dzdp_num1")] public int DzdpNum1 { get; set; }
        [Column("dzdp_num2")] public int DzdpNum2 { get; set; }
        [Column("dzdp_num3")] public int DzdpNum3 { get; set; }
        [Column("dg_num")] public int DgNum { get; set; }
        [Column("dgdp_num")] public int DgdpNum { get; set; }
        [Column("dpsokl")] public int Dpsokl { get; set; }
        [Column("dsorder_num")] public int DsorderNum { get; set; }
        [Column("dstermination_num")] public int DsterminationNum { get; set; }
        [Column("dzfuture_num")] public int DzfutureNum { get; set; }
        [Column("dzothers")] public int Dzothers { get; set; }
        [Column("uniqNumSB")] public string UniqNumSb { get; set; }
        [Column("Target")] public string Target { get; set; }
        [Column("RequestDate")] public DateTime? RequestDate { get; set; }
        [Column("isOUworks")] public int IsOUworks { get; set; }
        [Column("creditDate")] public DateTime? CreditDate { get; set; }
        [Column("decisionFilePath")] public string DecisionFilePath { get; set; }
        [Column("orderFilePath")] public string OrderFilePath { get; set; }
        [Column("initCl")] public string InitCl { get; set; }
        [Column("doc24Id")] public string Doc24Id { get; set; }
        [Column("isGovermentGrant")] public bool IsGovermentGrant { get; set; }
        [Column("isIndividualGraph")] public bool IsIndividualGraph { get; set; }
    }
}