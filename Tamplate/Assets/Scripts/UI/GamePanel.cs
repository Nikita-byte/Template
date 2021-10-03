using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class GamePanel : BasePanel
{
    [SerializeField] private Button _mainMenu;
    [SerializeField] private Button _shotButton;
    [SerializeField] private Text _score;
    [SerializeField] private Text _highScore;

    private void Awake()
    {
        _mainMenu.onClick.AddListener(() => EventManager.Instance.Events[EventType.MainMenu].Invoke());
        SetScore(0);
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

    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }

    public void SetRecord(int score)
    {
        //_highScore.text = score.ToString();
    }

    public Button GetShotButton()
    {
        return _shotButton;
    }
}