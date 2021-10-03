


public class ScreenInterface
{
    public static ScreenInterface Instance = new ScreenInterface();

    private ScreenFactory _screenFactory;
    private BasePanel _currentPanel;

    public ScreenInterface()
    {
        _screenFactory = new ScreenFactory();
    }

    public void Execute(PanelType panelType)
    {
        if (_currentPanel != null)
        {
            _currentPanel.Hide();
        }

        switch (panelType)
        {
            case PanelType.MainMenu:
                _currentPanel = _screenFactory.MainMenu;
                break;
            case PanelType.GamePanel:
                _currentPanel = _screenFactory.GamePanel;
                break;
            case PanelType.Settings:
                _currentPanel = _screenFactory.SettingsPanel;
                break;
            case PanelType.EndGamePanel:
                _currentPanel = _screenFactory.EndGamePanel;
                break;
            case PanelType.HighScorePanel:
                _currentPanel = _screenFactory.HighScorePanel;
                break;
        }

        _currentPanel.Show();
    }
}
