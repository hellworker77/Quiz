﻿using Models.Abstraction;

namespace Models.Implementation;

public class QuestionDto : AbstractQuestionDto
{
    public Guid TestId { get; set; }
}