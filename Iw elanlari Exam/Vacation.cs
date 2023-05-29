public class Vacation
{
    public Vacation(Employer employer, string? vacationsName, string? junMidSen, string? description, int? salary)
    {
        EmployerInformation = employer;
        VacationsName = vacationsName;
        JunMidSen = junMidSen;
        Description = description;
        Salary = salary;
        EmployeeString = EmployerInformation.ToString();
    }
    public Vacation(string? vacationsName, string? junMidSen, string? description, int? salary)
    {
        VacationsName = vacationsName;
        JunMidSen = junMidSen;
        Description = description;
        Salary = salary;
    }
    public void MessageToEmp(Worker worker, string message) => EmployerInformation.NewNotification(worker, new Notification(message));
    public Employer EmployerInformation { private get; set; }
    public string? EmployeeString { private get; set; }
    public string? VacationsName { get; set; }
    public string? JunMidSen { get; set; }
    public string? Description { get; set; }
    public int? Salary { get; set; }


    public override string ToString()
    {
        return
            $"{VacationsName}\n" +
            $"Experience:{JunMidSen}\n" +
            $"Description:{Description}\n" +
            $"Salary:{Salary + "$"}\n";
    }
}
