using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.VisualBasic;


class Program
{
    static void Main(string[] args)
    {
        //Employer emp = new Employer("Cemil", "Hesenov", new DateTime(1994, 6, 17), "0504525458", "1212", new Vacation(".NET C# developer", "Senior", "taxta baw olmasin esas", 4000));


        List<Vacation> vacations = new List<Vacation>()
        {
         new Vacation("C# developer", "sen", "99 il tecrube", 1234),
         new Vacation("C++ developer", "jun", "ne bilir bilsin teki gelsin", 4000),
        };
        List<Employer> employeers = new List<Employer>() {

        new Employer("Cemil", "Hesenov", new DateTime(1994, 6, 17), "0504525458", "1212",vacations),
        new Employer("Emil", "Hesenov", new DateTime(1994, 6, 17), "0504525458", "1212", new Vacation(".NET C# developer", "Senior", "taxta baw olmasin esas", 4000)),
        new Employer("Shamil", "Hesenov", new DateTime(1994, 6, 17), "0504525458", "1212", new Vacation(".NET C# developer", "Senior", "taxta baw olmasin esas", 4000))
        };
        List<Worker?> workers = new List<Worker?>() {
        new Worker("Elnur", "Bagirov","1919" ,new DateTime(1994, 6, 17), "C# developer", "212", "300 bal", "C# .NEt C++ SQl HTML CSS", "Google", new DateTime(2015, 6, 18), new DateTime(2018, 1, 10), "English b1", true),
        new Worker("Hesen", "Nagiyev","1818" ,new DateTime(1994, 6, 17), "C# developer", "212", "300 bal", "C# .NEt C++ SQl HTML CSS", "Google", new DateTime(2015, 6, 18), new DateTime(2018, 1, 10), "English b1", true),
        };

        BossAz bossAz = new BossAz(employeers, workers);
        bossAz.Start();
        //BossAz.AddNewEmployee(employer);
        //foreach (var item in BossAz.Employers)
        //{
        //    Console.WriteLine(item);
        //}
        //string jsonFilePath = @"Vacations.json";

        //string? jsonString = File.ReadAllText(jsonFilePath);
        //if (!(string.IsNullOrEmpty(jsonString)))
        //{
        //    people = JsonSerializer.Deserialize<List<Employer?>?>(jsonString);
        //}
        //else
        //{
        //string input = "This is a string\nwith multiple\nend lines.";

        //// Replace line breaks with a placeholder
        //string modifiedInput = input.Replace("\n", "<br>");

        //// Serialize the modified string to JSON
        //string json2 = JsonConvert.SerializeObject(modifiedInput, Formatting.Indented);

        //// Restore line breaks in the JSON
        //json2 = json2.Replace("<br>", "\n" + '"');

        //Console.WriteLine(json);
        //File.WriteAllText(jsonFilePath, json);

        //}
        //foreach (var item in people)
        //{
        //    Console.WriteLine(item);
        //}
        //File.Delete(jsonFilePath);
        //List<Person> people2 = new List<Person> { };

    }
}