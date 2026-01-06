using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCapsuleMirror.Domain.Common;

namespace TimeCapsuleMirror.Domain.Entities;

public class DailyAnswer : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid QuestionId { get; private set; }
    public string AnswerText { get; private set; } = default!;
    public DateOnly AnswerDate { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private DailyAnswer() { }

    public DailyAnswer(Guid userId, Guid questionId, string answerText, DateOnly answerDate)
    {
        if (string.IsNullOrWhiteSpace(answerText))
            throw new ArgumentException("Answer is required.");

        UserId = userId;
        QuestionId = questionId;
        AnswerText = answerText.Trim();
        AnswerDate = answerDate;
        CreatedAt = DateTime.UtcNow;
    }
}
