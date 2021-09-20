using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarantsService.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public int Id { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("username")] public string Username { get; set; }
        [Column("email")] public string Email { get; set; }
        [Column("password")] public string Password { get; set; }
        [Column("block")] public bool Block { get; set; }
        [Column("sendEmail")] public bool SendEmail { get; set; }
        [Column("registerDate")] public DateTime RegisterDate { get; set; }
        [Column("lastvisitDate")] public DateTime LastvisitDate { get; set; }
        [Column("activation")] public string Activation { get; set; }
        [Column("params")] public string Params { get; set; }
        [Column("lastResetTime")] public DateTime LastResetTime { get; set; }
        [Column("resetCount")] public int ResetCount { get; set; }
        [Column("otpKey")] public string OtpKey { get; set; }
        [Column("otep")] public string Otep { get; set; }
        [Column("requireReset")] public bool RequireReset { get; set; }
        [Column("positionId")] public int PositionId { get; set; }
        [Column("filialId")] public int FilialId { get; set; }
        [Column("teamId")] public int TeamId { get; set; }
    }
}