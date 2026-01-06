using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCapsuleMirror.Domain.Common;

namespace TimeCapsuleMirror.Domain.Entities;

public class TimeCapsule : BaseEntity
{
    public string Title { get; private set; } = default!;
    public string Body { get; private set; } = default!;
    public DateTime UnlockAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? OpenedAt { get; private set; }

    private TimeCapsule() { } // for EF Core later

    public TimeCapsule(string title, string body, DateTime unlockAtUtc)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required.");

        if (unlockAtUtc <= DateTime.UtcNow)
            throw new ArgumentException("Unlock date must be in the future.");

        Title = title.Trim();
        Body = body ?? string.Empty;
        UnlockAt = unlockAtUtc;
        CreatedAt = DateTime.UtcNow;
    }

    public bool CanOpen(DateTime nowUtc) => nowUtc >= UnlockAt;

    public void Open(DateTime nowUtc)
    {
        if (!CanOpen(nowUtc))
            throw new InvalidOperationException("Capsule is still locked.");

        OpenedAt ??= nowUtc; // only set once
    }
}
