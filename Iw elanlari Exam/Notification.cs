public class Notification
{
    public Notification(string? not)
    {
        Not += DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":" + not;
    }
    public override string ToString()
    {
        return $"{Not}";
    }
    public string? Not { get; set; } = "";
}
