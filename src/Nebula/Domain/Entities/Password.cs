using Nebula.Domain.Common;

namespace Nebula.Domain.Entities;

public class Password : BaseEntity, IAuditedEntity
{
    public string Title { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public string? ServiceURI { get; set; }
    public string Value { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
}