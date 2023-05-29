public abstract class Person
{
    public Person(string? name, string? surname, DateTime birthdayYear)
    {
        Name = name;
        Surname = surname;
        Age = DateTime.Now.Year - birthdayYear.Year;
    }
    public string? ID { get; set; } = UseMethods.GetShortID();
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Id:{ID}\nName:{Name}\nSurname:{Surname}\nAge:{Age}";
    }

}
