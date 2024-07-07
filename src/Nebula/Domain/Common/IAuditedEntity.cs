namespace Nebula.Domain.Common;

public interface IAuditedEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
}