using UnityEngine.UI;
using UnityEngine;


public class ScreenFactory
{
    private GameObject _canvas;
    private MainMenu _mainMenu;
    private GamePanel _gamePanel;
    private SettingsPanel _settingsPanel;
    private EndGamePanel _endGamePanel;
    private HighScorePanel _highScorePanel;


    public ScreenFactory()
    {
        if (_canvas == null)
        {
            GameObject go = Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Canvas]);
            _canvas = GameObject.Instantiate(go);
            _canvas.gameObject.SetActive(true);
        }
    }

    public MainMenu MainMenu
    {
        get
        {
            if (_mainMenu == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.MainMenu]), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _mainMenu = go.GetComponent<MainMenu>();

                _mainMenu.SetScreen(ObjectPool.Instance.GetSprites()["Screen-2"]);
                _mainMenu.SetPlayButton(ObjectPool.Instance.GetSprites()["Play"]);
                _mainMenu.SetSettingsButton(ObjectPool.Instance.GetSprites()["Settings"]);
                _mainMenu.SetHighScoreButton(ObjectPool.Instance.GetSprites()["Best"]);
            }
            return _mainMenu;
        }
    }

    public GamePanel GamePanel
    {
        get
        {
            if (_gamePanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.GamePanel]), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _gamePanel = go.GetComponent<GamePanel>();

                _gamePanel.SetMenuButton(ObjectPool.Instance.GetSprites()["Menu"]);
            }

            return _gamePanel;
        }
    }

    public EndGamePanel EndGamePanel
    {
        get
        {
            if (_endGamePanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.EndGamePanel]), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _endGamePanel = go.GetComponent<EndGamePanel>();

                _endGamePanel.SetScreen(ObjectPool.Instance.GetSprites()["Screen-3"]);
                _endGamePanel.SetPlayButton(ObjectPool.Instance.GetSprites()["Repeat"]);
                _endGamePanel.SetMenuButton(ObjectPool.Instance.GetSprites()["Back"]);
            }
            return _endGamePanel;
        }
    }

    public SettingsPanel SettingsPanel
    {
        get
        {
            if (_settingsPanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.SettingsPanel]), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _settingsPanel = go.GetComponent<SettingsPanel>();

                _settingsPanel.SetScreen(ObjectPool.Instance.GetSprites()["Screen-1"]);
                _settingsPanel.SetBackButton(ObjectPool.Instance.GetSprites()["Back"]);

                _settingsPanel.SetVibroOnButton(ObjectPool.Instance.GetSprites()["Vibro on"]);
                _settingsPanel.SetVinroOffButton(ObjectPool.Instance.GetSprites()["Vibro off"]);
                _settingsPanel.SetSounOnButton(ObjectPool.Instance.GetSprites()["Sound on"]);
                _settingsPanel.SetSoundOffButton(ObjectPool.Instance.GetSprites()["Sound off"]);
            }

            return _settingsPanel;
        }
    }

    public HighScorePanel HighScorePanel
    {
        get
        {
            if (_highScorePanel == null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.HighScorePanel]), _canvas.transform.position, Quaternion.identity, _canvas.transform);
                _highScorePanel = go.GetComponent<HighScorePanel>();

                _highScorePanel.SetScreen(ObjectPool.Instance.GetSprites()["Screen-4"]);
                _highScorePanel.SetBackButton(ObjectPool.Instance.GetSprites()["Back"]);
            }

            return _highScorePanel;
        }
    }
}
