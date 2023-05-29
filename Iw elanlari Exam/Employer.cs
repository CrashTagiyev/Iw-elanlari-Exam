using Newtonsoft.Json;

public class Employer : Person, IPassword
{
    private string PersonalJsonFilePath { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Vacation?> Vacations { get; set; } = new List<Vacation?> { };
    public List<Notification?> Notifications { get; private set; } = new List<Notification?> { };
    public string? Password { get; set; }
    public Employer(string? name, string? surname, DateTime birthdayYear, string? phoneNumber, string password, params Vacation[] vacations) : base(name, surname, birthdayYear)
    {
        Password = password;
        PhoneNumber = phoneNumber;
        NewVacations(vacations);
        PersonalJsonFilePath = $"{Name + " " + Surname + " Notifications"}.json";
    }
    public Employer(string? name, string? surname, DateTime birthdayYear, string? phoneNumber, string password, List<Vacation> vacations) : base(name, surname, birthdayYear)
    {
        Password = password;
        PhoneNumber = phoneNumber;
        NewVacations(vacations);
        PersonalJsonFilePath = $"{Name + " " + Surname + " Notifications"}.json";
    }
    public void ShowAllVacations() => Vacations?.ForEach(vacation => Console.WriteLine(vacation));
    public void ShowAllNotifications() { Notifications?.ForEach(notification => Console.WriteLine(notification)); }
    public void NewNotification(Worker worker, Notification? newNotification)
    {
        newNotification.Not = worker.Name + worker.Surname + "\n" + newNotification.Not;
        Notifications.Add(newNotification);
        string json = JsonConvert.SerializeObject(Notifications, Formatting.Indented);
        File.WriteAllText(PersonalJsonFilePath, json);

    }
    public void NewVacations(params Vacation[] newVac)
    {
        for (int i = 0; i < newVac.GetLength(0); i++)
        {
            newVac[i].EmployerInformation = this;
            Vacations.Add(newVac[i]);
        }
    }
    public void NewVacations(List<Vacation> newVac)
    {
        for (int i = 0; i < newVac.Count; i++)
        {
            newVac[i].EmployerInformation = this;
            Vacations.Add(newVac[i]);
        }
    }
    public void NewVacations(Vacation newVac)
    {
        newVac.EmployerInformation = this;
        Vacations.Add(newVac);
    }
    public string? VacationsToString()
    {
        string? temp = "";
        for (int i = 0; i < Vacations.Count; i++)
        {
            temp += $"{i + 1}:" + Vacations[i] + "\n\n";
        }
        if (temp == null) return null;
        return temp;
    }
    public override string ToString()
    {
        return $"{Name + " " + Surname} (Phone number: {PhoneNumber})\nVacations:\n{VacationsToString()}";
    }
}
