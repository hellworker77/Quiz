namespace Models.Implementation.Answers;

public struct TestAnswer
{
    public Guid TestId { get; set; }
    public List<QuestionAnswer> Answers { get; set; }
}
