using Messenger.Api.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Api.Entities.Chat;

[Table("tbl_chat_message_reads")]
public class ChatMessageReadEntity
{
    public long MessageId { get; set; }
    public ChatMessageEntity? Message { get; set; }

    public long UserId { get; set; }
    public UserEntity? User { get; set; }

    public DateTime ReadAt { get; set; } = DateTime.UtcNow;
}

