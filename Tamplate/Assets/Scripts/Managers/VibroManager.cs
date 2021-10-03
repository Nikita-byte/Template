

public class VibroManager
{
    public static VibroManager Instance = new VibroManager();

    public bool IsEnabled { get; set; } = true;

    public void TurnOn()
    {
        IsEnabled = true;
    }

    public void TurnOff()
    {
        IsEnabled = false;
    }
}
