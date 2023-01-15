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

    private static string UserPhotoFilePath = "fakeImages/profile/photo.jpg";


    public static ICollection<MediaUser> MediaUsers = new List<MediaUser>
    {
        new MediaUser
        {
            Data = File.ReadAllBytes(UserPhotoFilePath),
            FileName = "photo.jpg",
            Name = "image"
        }
    };
    public static ICollection<MediaTest> MediaTests = new List<MediaTest>
    {
        new MediaTest
        {
            Data = File.ReadAllBytes("fakeImages/test/image.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        }
    };
    public static ICollection<MediaQuestion> MediaQuestions = new List<MediaQuestion>
    {
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/1.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/2.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/3.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/4.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/5.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/6.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/7.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/8.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/9.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        },
        new MediaQuestion
        {
            Data = File.ReadAllBytes("fakeImages/question/10.jpg"),
            FileName = "photo.jpg",
            Name = "image"
        }
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
            SecurityStamp = Guid.NewGuid().ToString("D"),
            Photo = MediaUsers.First(),
            Rating = 2400
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
            SecurityStamp = Guid.NewGuid().ToString("D"),
            Photo = MediaUsers.First(),
            Rating = 7600
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
            Name = "Знание вселенной Warcraft",
            Description = "description",
            Date = DateTimeOffset.Now.AddDays(-2),
            Photo = MediaTests.First(),
            Stamp = "OZVV5TpP4U6wJthaCORZEQ"
        },
    };

    public static ICollection<Question> Questions = new List<Question>
    {
        new Question
        {
            Title = "Как альянс узнал о истиных планах Нер'зула во время повторого открытия Тёмного Портала",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Шпион смог пробраться в лагерь клана Песни Войны и подслушать разговор",
                "Информацию для альянса тайно добыла Гарон",
                "Кадгар смог проникнуть в разум одного из вождей",
                "Агентура альянса поймала одного из орков и выбила информацию пытками",
                "Оргримм сдал своих соплеменников, когда узнал, что те убили Дуротана с женой и ребёнком"
            }),
            CorrectAnswer = "Агентура альянса поймала одного из орков и выбила информацию пытками",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(0).First()
        },
        new Question
        {
            Title = "Откуда ночные эльфы узнали об Элуне?",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Узрели её в Колодце Вечности",
                "Её лик явился в звёздном небе",
                "О ней поведали Наару",
                "Эти знания передались от предков-троллей",
                "Узнали о ней от Диких Богов"
            }),
            CorrectAnswer = "Узрели её в Колодце Вечности",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(1).First()
        },
        new Question
        {
            Title = "Какой элемент применили человеческие маги для уничтожения армии троллей Амани вместе с их лидером Джинтха",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Огонь",
                "Земля",
                "Молнии",
                "Тайная магия",
                "Свет"
            }),
            CorrectAnswer = "Огонь",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(2).First()
        },
        new Question
        {
            Title = "Какая из этих стихий изначально преобладала над остальными в Дреноре",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Огонь",
                "Земля",
                "Вода",
                "Воздух",
                "Жизнь"
            }),
            CorrectAnswer = "Жизнь",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(3).First()
        },
        new Question
        {
            Title = "Как звали вожака гноллов, который доставил больше всего проблем королю Баратену",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Фангран",
                "Варгнир",
                "Гарфанг",
                "Хоггер"
            }),
            CorrectAnswer = "Гарфанг",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(4).First()
        },
        new Question
        {
            Title = "Кто основал первый Солнечный Колодец",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Кель'тас",
                "Анвина",
                "Анастериан",
                "Тер'велас",
                "Дат’ремар"
            }),
            CorrectAnswer = "Дат’ремар",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(5).First()
        },
        new Question
        {
            Title = "Именно этого арефакта не было у Нер'Зула, когда он начал открывать порталы, что разрушили Дренор",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Скипетр Саргераса",
                "Череп Гул'дана",
                "Книга Медива",
                "Око Даларана"
            }),
            CorrectAnswer = "Череп Гул'дана",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(6).First()
        },
        new Question
        {
            Title = "В какой город привели дренеи спасённых Оргрима и Дуротана",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Шаттрат",
                "Аукиндон",
                "Телмор",
                "Карабор"
            }),
            CorrectAnswer = "Телмор",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(7).First()
        }
        ,
        new Question
        {
            Title = "Какой была переодичность крупномасштабных набегов Клакси на империю Могу",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Раз в 10 лет",
                "Раз в 70 лет",
                "Раз в 100 лет",
                "Раз в 500 лет",
                "Раз в 1000 лет"
            }),
            CorrectAnswer = "Раз в 100 лет",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(8).First()
        }
        ,
        new Question
        {
            Title = "Кто из более младших рас первыми смогли убить гронна в бою 1 на 1",
            AnswersAsJson = JsonConvert.SerializeObject(new string[]
            {
                "Огронны",
                "Огры",
                "Орки",
                "Дренеи",
                "Здесь нет верного варианта"
            }),
            CorrectAnswer = "Огры",
            Test = Tests.First(x=>x.Name.Equals("Знание вселенной Warcraft")),
            Photo = MediaQuestions.Skip(9).First()
        }
    };

    public static ICollection<TestResult> TestResults = new List<TestResult>();

    public static ICollection<QuestionResult> QuestionResults = new List<QuestionResult>();
}