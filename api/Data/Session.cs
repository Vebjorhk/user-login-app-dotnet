using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data;

[Table("session")]
public class Session
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }
    public User User { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAtUtc { get; set; }

    [Column("expires_at")]
    public DateTime ExpiresAtUtc { get; set; }

    [Column("last_seen_at")]
    public DateTime? LastSeenAtUtc { get; set; }
}