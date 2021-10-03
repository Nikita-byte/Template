using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class HighScorePanel : BasePanel
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Text _highScore;

    private void Awake()
    {
        _mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
        SetRecord();
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

    public void SetMenuButton(Sprite sprite)
    {
        _mainMenu.GetComponent<Image>().sprite = sprite;
    }

    public void SetScreen(Sprite screen)
    {
        GetComponent<Image>().sprite = screen;
    }

    public void SetBackButton(Sprite sprite)
    {
        _mainMenu.GetComponent<Image>().sprite = sprite;
    }

    public void SetRecord()
    {
        int score = ScoreSaver.Instance.LoadScore();
        _highScore.text = score.ToString();
    }
}