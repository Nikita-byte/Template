using UnityEngine;


public class Counter : ITurnOn
{
    private GamePanel _gamepanel;
    private int _gamescore;

    public int GameScore => _gamescore;

    public Counter()
    {
        EventManager.Instance.ScoreEvent += SetScore;
        //EventManager.Instance.AddListener(EventType.Death, SaveScore);
    }

    public void TurnOn()
    {
        _gamepanel = GameObject.FindObjectOfType<GamePanel>();
        NulifyScore();
        _gamepanel.SetRecord(ScoreSaver.Instance.LoadScore());
    }

    public void TurnOff()
    {
        SaveScore();
    }

    private void NulifyScore()
    {
        _gamescore = 0;
        _gamepanel.SetScore(_gamescore);
    }

    private void SetScore(int score)
    {
        _gamescore += score;
        _gamepanel.SetScore(_gamescore);
    }

    private void SaveScore()
    {
        ScoreSaver.Instance.SaveRecord(_gamescore);
    }
}
