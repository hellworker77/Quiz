using Entities.Entity;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DataAccessLayer.Data;

public static class FakeData
{
    private static readonly ICollection<string> Answers = new List<string>
    {
        "answer 1",
        "answer 2",
        "answer 3"
    };

    public static ICollection<IdentityRole<Guid>> Roles = new List<IdentityRole<Guid>>
    {
        new IdentityRole<Guid>
        {
            Id = Guid.NewGuid(),
            Name = "admin",
            NormalizedName = "admin"
        },
        new IdentityRole<Guid>
        {
            Id = Guid.NewGuid(),
            Name = "user",
            NormalizedName = "user"
        }
    };
    public static ICollection<User> Users = new List<User>
    {
        new User
        {
            Id = Guid.NewGuid(),
            Email = "admin@aaa.com",
            NormalizedEmail = "admin@aaa.com",
            UserName = "admin",
            NormalizedUserName = "admin",
            EmailConfirmed = true,
            PasswordHash =
                "AQAAAAEAACcQAAAAEHOnF+aiX0aOAcQTNVLA4BNSmJ3aJVLcgq4JtmUakxr/xYQs9CPHyZwRJ9iK2MJfQg==", // !QAZ2wsx
            SecurityStamp = Guid.NewGuid().ToString("D")
        },
        new User
        {
            Id = Guid.NewGuid(),
            Email = "user@aaa.com",
            NormalizedEmail = "user@aaa.com",
            UserName = "user",
            NormalizedUserName = "user",
            EmailConfirmed = true,
            PasswordHash =
                "AQAAAAEAACcQAAAAEHOnF+aiX0aOAcQTNVLA4BNSmJ3aJVLcgq4JtmUakxr/xYQs9CPHyZwRJ9iK2MJfQg==", // !QAZ2wsx
            SecurityStamp = Guid.NewGuid().ToString("D")
        }
    };
    public static ICollection<IdentityUserRole<Guid>> UserRoles = new List<IdentityUserRole<Guid>>
    {
        new IdentityUserRole<Guid>
        {
            UserId = Users.First().Id,
            RoleId = Roles.First().Id
        },
        new IdentityUserRole<Guid>
        {
            UserId = Users.Last().Id,
            RoleId = Roles.Last().Id
        }
    };
    public static ICollection<Test> Tests = new List<Test>
    {
        new Test
        {
            Name = "test",
            Description = "description",
            Date = DateTimeOffset.Now.AddDays(-2)
        }
    };
    public static ICollection<Question> Questions = new List<Question>
    {
        new Question
        {
            Title = "Title 1",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            Test = Tests.First()
        },
        new Question
        {
            Title = "Title 2",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            Test = Tests.Last()
        },
        new Question
        {
            Title = "Title 3",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            Test = Tests.Last()
        },
    };

    public static ICollection<TestResult> TestResults = new List<TestResult>
    {
        new TestResult
        {
            User = Users.First(),
            Name = "test",
            Description = "description",
            Date = DateTimeOffset.Now
        }
    };

    public static ICollection<QuestionResult> QuestionResults = new List<QuestionResult>()
    {
        new QuestionResult
        {
            Title = "Title 1",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            ActualAnswer = Answers.Last(),
            IsCorrect = false,
            TestResult = TestResults.First()
        },
        new QuestionResult
        {
            Title = "Title 2",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            ActualAnswer = Answers.Last(),
            IsCorrect = false,
            TestResult = TestResults.First()
        },
        new QuestionResult
        {
            Title = "Title 3",
            AnswersAsJson = JsonConvert.SerializeObject(Answers),
            CorrectAnswer = Answers.First(),
            ActualAnswer = Answers.Last(),
            IsCorrect = false,
            TestResult = TestResults.First()
        }
    };
}