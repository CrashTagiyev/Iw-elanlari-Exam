public static class UseMethods
{
    public static string GetShortID()
    {
        Guid TempGuid = Guid.NewGuid();
        string shortGUidString = "";
        for (int i = 0; i < 8; i++)
        {
            shortGUidString += TempGuid.ToString()[i];
        }
        return shortGUidString;
    }
}
