using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;


public class MainMenu : BasePanel
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _highScore;

    private void Awake()
    {
        _play.onClick.AddListener(()=> EventManager.Instance.Events[EventType.StartGame].Invoke());
        _settings.onClick.AddListener(() => ScreenInterface.Instance.Execute(PanelType.Settings));
        _highScore.onClick.AddListener(() => ScreenInterface.Instance.Execute(PanelType.HighScorePanel));
    }

    public override void Hide()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(-350, 0), 0.3f);
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.3f);
    }

    public void SetScreen(Sprite screen)
    {
        GetComponent<Image>().sprite = screen;
    }

    public void SetPlayButton(Sprite playButton)
    {
        _play.GetComponent<Image>().sprite = playButton;
    }

    public void SetHighScoreButton(Sprite playButton)
    {
        _highScore.GetComponent<Image>().sprite = playButton;
    }

    public void SetSettingsButton(Sprite sprite)
    {
        _settings.GetComponent<Image>().sprite = sprite;
    }
}
