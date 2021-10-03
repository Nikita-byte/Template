using System;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class EndGamePanel : BasePanel
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Text _highScore;
    [SerializeField] private Text _score;
    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _play.onClick.AddListener(() => EventManager.Instance.Events[EventType.StartGame].Invoke());
        _mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
    }

    public void SetScore(int score, int highscore)
    {
        _score.text = score.ToString();
        _highScore.text = highscore.ToString();
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

    public void SetMenuButton(Sprite sprite)
    {
        _mainMenu.GetComponent<Image>().sprite = sprite;
    }

    public void StartButton()
    {
        _startButton.gameObject.SetActive(false);
    }
}