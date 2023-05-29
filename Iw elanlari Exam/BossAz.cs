using System.Data;
using Newtonsoft.Json;

public class BossAz
{
    public List<Employer> Employeers { get; private set; } = new List<Employer> { };
    public List<Worker?> Workers { get; private set; } = new List<Worker?> { };
    public List<Vacation?> Vacations { get; private set; } = new List<Vacation?> { };
    public BossAz(List<Employer> employers, List<Worker?> workers)
    {
        employers.ForEach(employee => AddNewEmployee(employee));
        workers.ForEach(worker => AddNewWorker(worker));
        AddNewVacations();
    }
    public void ShowVacations()
    {
        for (int i = 0; i < Vacations.Count; i++)
        {
            Console.WriteLine($"{i + 1}:" + Vacations[i] + "\n\n");
        }
    }
    public void ShowWorkers()
    {
        for (int i = 0; i < Workers.Count; i++)
        {
            Console.WriteLine($"{i + 1}:" + Workers[i] + "\n\n");
        }
    }
    public void AddNewWorker(Worker? newWorker)
    {
        Workers.Add(newWorker);
        var json = JsonConvert.SerializeObject(Workers, Formatting.Indented);
        File.WriteAllText(JsonPathways.WorkerPath, json);
    }
    public void AddNewEmployee(Employer newEmployee)
    {
        Employeers.Add(newEmployee);
        var json = JsonConvert.SerializeObject(Employeers, Formatting.Indented);
        File.WriteAllText(JsonPathways.EmployeePath, json);
    }
    public void AddNewVacations()
    {
        for (int i = 0; i < Employeers.Count; i++)
        {
            for (int j = 0; j < Employeers[i].Vacations.Count; j++)
            {

                Vacations.Add(Employeers[i].Vacations[j]);
            }
        }
        var json = JsonConvert.SerializeObject(Vacations, Formatting.Indented);
        File.WriteAllText(JsonPathways.VacationPath, json);
    }

    public Employer? CheckEmpPass(string? pass)
    {
        if (pass != null)
        {

            for (int i = 0; i < Employeers.Count; i++)
            {
                if (Employeers[i].Password == pass) return Employeers[i];
            }
        }
        return null;
    }
    public Worker? CheckWorkerPass(string? pass)
    {
        if (pass != null)
        {

            for (int i = 0; i < Workers.Count; i++)
            {
                if (Workers[i].Password == pass) return Workers[i];
            }
        }
        return null;
    }
    public void SelectWorkerAndSendNotification(Employer employee)
    {
        try
        {
            Console.WriteLine("Select(by number) who do you want:");
            string? SelectedWorkerIndex = Console.ReadLine();
            if (int.Parse(SelectedWorkerIndex) < 0 && int.Parse(SelectedWorkerIndex) > Workers.Count) throw new IndexOutOfRangeException("Out of range number");
            Console.WriteLine("Write a message(minimum 5 character):");
            string? message = Console.ReadLine();
            if (message == null) throw new NoNullAllowedException("NULL not allowed");
            if (message.Length < 5) throw new FormatException("Minimum 5 character");
            Workers[int.Parse(SelectedWorkerIndex) - 1].NewNotification(employee, new Notification(message));
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            SelectWorkerAndSendNotification(employee);
        }
    }
    public void SelectVacantionAndSendMessage(Worker worker)
    {
        try
        {
            Console.WriteLine("Select(by number) vacantion you want:");
            string? SelectedVacantionIndex = Console.ReadLine();
            if (int.Parse(SelectedVacantionIndex) < 0 && int.Parse(SelectedVacantionIndex) > Vacations.Count) throw new IndexOutOfRangeException("Out of range number");
            Console.WriteLine("Write a message(minimum 5 character):");
            string? message = Console.ReadLine();
            if (message == null) throw new NoNullAllowedException("NULL not allowed");
            if (message.Length < 5) throw new FormatException("Minimum 5 character");
            Vacations[int.Parse(SelectedVacantionIndex) - 1].MessageToEmp(worker, message);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            SelectVacantionAndSendMessage(worker);
        }
    }
    public void EmployeeInterface(Employer? employee)
    {
        try
        {
            Console.WriteLine("1:Show all people that looking for work\n2:Send notification to selected worker\n3:Show your notifications\n4 Exit");
            string? choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4") { throw new Exception("You must choice 1 or 2"); }
            switch (choice)
            {
                case "1": ShowWorkers(); break;
                case "2": SelectWorkerAndSendNotification(employee); break;
                case "3": employee.ShowAllNotifications(); break;
                case "4": return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        EmployeeInterface(employee);
    }

    public void WorkerInterface(Worker? worker)
    {
        try
        {
            Console.WriteLine("1:Show vacantions\n2:Send notification to selected Vacantion Employee\n3:Show your notifications\n4 Exit");
            string? choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4") { throw new Exception("You must choice 1 or 2"); }
            switch (choice)
            {
                case "1": ShowVacations(); break;
                case "2": SelectVacantionAndSendMessage(worker); break;
                case "3": worker.ShowNotifications(); break;
                case "4": return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        WorkerInterface(worker);
    }


    public void Start()
    {
        try
        {
            string? WritePass;
            string? choice;

            Console.WriteLine("1:Employee\n2:Worker\n3:Exit");
            choice = Console.ReadLine();
            if (choice != "1" && choice != "2") throw new Exception("U must choice 1,2 or 3");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Write a Employee password(1212)");
                    WritePass = Console.ReadLine();
                    if (CheckEmpPass(WritePass) != null)
                    {
                        EmployeeInterface(CheckEmpPass(WritePass));
                    }
                    else
                    {
                        throw new Exception("Wrong password try next time");
                    }
                    break;
                case "2":
                    Console.WriteLine("Write worker password:");
                    WritePass = Console.ReadLine();
                    if (CheckWorkerPass(WritePass) != null)
                    {
                        WorkerInterface(CheckWorkerPass(WritePass));
                    }
                    else
                    {
                        throw new Exception("Wrong password try next time");
                    }
                    break;
                case "3": return;
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        Start();
    }

}
