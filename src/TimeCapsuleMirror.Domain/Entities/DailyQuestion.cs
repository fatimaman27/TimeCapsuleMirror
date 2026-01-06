using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCapsuleMirror.Domain.Common;

namespace TimeCapsuleMirror.Domain.Entities;

public class DailyQuestion : BaseEntity
{
    public string QuestionText { get; private set; } = default!;
    public DateOnly ActiveDate { get; private set; }

    private DailyQuestion() { }

    public DailyQuestion(string questionText, DateOnly activeDate)
    {
        if (string.IsNullOrWhiteSpace(questionText))
            throw new ArgumentException("Question text is required.");

        QuestionText = questionText.Trim();
        ActiveDate = activeDate;
    }
}
