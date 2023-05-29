using Newtonsoft.Json;

public class Worker : Person, ICV, IPassword
{
    public string WorkersPersonalJsonPath { get; private set; }
    public Worker(string? name, string? surname, string password, DateTime birthdayYear, string? ixtisas, string? school, string? universityScore, string? skills, string? cOmpanies, DateTime startingTime, DateTime endingTime, string? languagesYouKnow, bool highEducation)
    : base(name, surname, birthdayYear)
    {
        Password = password;
        Ixtisas = ixtisas;
        School = school;
        UniversityScore = universityScore;
        Skills = skills;
        COmpanies = cOmpanies;
        StartingAndEndingWorkTimes += $"{startingTime.ToShortDateString()} to {endingTime.ToShortDateString()}";
        LanguagesYouKnow = languagesYouKnow;
        HighEducation += (highEducation) ? "Yes" : "No";
        WorkersPersonalJsonPath = $"{Name + " " + Surname + " notifications"}.json";
    }
    public List<Notification> notifications { private get; set; } = new List<Notification>();
    public string? Ixtisas { get; set; }
    public string? School { get; set; }
    public string? UniversityScore { get; set; }
    public string? Skills { get; set; }
    public string? COmpanies { get; set; }
    public string? StartingAndEndingWorkTimes { get; set; } = "";
    public string? LanguagesYouKnow { get; set; }
    public string? HighEducation { get; set; }
    public string? Password { get; set; }


    public void ShowNotifications() => notifications.ForEach(not => Console.WriteLine(not));
    public void NewNotification(Employer employer, Notification notification)
    {
        notification.Not = employer.Name + employer.Surname + ":" + notification.Not;
        notifications.Add(notification);
        string json = JsonConvert.SerializeObject(notifications, Formatting.Indented);
        File.WriteAllText(WorkersPersonalJsonPath, json);
    }

    public string CvToString()
    {
        return $"\nIxtisas:{Ixtisas}" +
        $"\nSchool:{School}" +
        $"\nSkills:{Skills}" +
        $"\nCompanies i worked:{COmpanies}" +
        $"\nStarting and ending worked times:{StartingAndEndingWorkTimes}" +
        $"\nLanguages i know:{LanguagesYouKnow}" +
        $"\nHigh education:{HighEducation}";
    }
    public override string ToString()
    {
        return $"{base.ToString()}\n\nDescription:" + CvToString();
    }

}
