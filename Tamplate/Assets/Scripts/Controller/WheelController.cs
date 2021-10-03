using UnityEngine;
using System.Collections.Generic;


public class WheelController : ITurnOn, IUpdate
{
    private EndGamePanel _endGamePanel;
    private int _score;
    private int _record;
    private Wheel _wheel;
    private GameObject _bg;

    public WheelController()
    {
        EventManager.Instance.AddListener(EventType.StartWheel, StartWheel);
        EventManager.Instance.ScoreWheelEvent += ChangeBonus;
    }

    public void FixedUpdate()
    {
    }

    public void LateUpdate()
    {
    }

    public void TurnOff()
    {
        _wheel.gameObject.SetActive(false);
        _bg.SetActive(false);
    }

    public void TurnOn()
    {
        if (_endGamePanel == null)
        {
            _endGamePanel = GameObject.FindObjectOfType<EndGamePanel>();
        }

        _wheel = ObjectPool.Instance.GetObject(ObjectType.Wheel).GetComponent<Wheel>();
        _bg = ObjectPool.Instance.GetObject(ObjectType.Black);

        _wheel.gameObject.SetActive(true);
        _bg.SetActive(true);


        _score = PlayerPrefs.GetInt("Score", 0);
        _record = PlayerPrefs.GetInt("Record", 0);

        _endGamePanel.SetScore(_score, _record);
    }

    public void Update()
    {
        _wheel.UpdateWheel();
    }

    private void StartWheel()
    {
        _wheel.StartWheel();
        _endGamePanel.StartButton();
    }

    private void ChangeBonus(int number)
    {
        switch (number)
        {
            case 250:
                _score += 250;
                break;
            case 50:
                _score += 50;
                break;
            case 3:
                _score *= 3;
                break;
            case 150:
                _score += 150;
                break;
            case 300:
                _score += 300;
                break;
            case 100:
                _score += 100;
                break;
            case 2:
                _score *= 2;
                break;
            case 200:
                _score += 200;
                break;
        }

        if (_score >= _record)
        {
            _record = _score;
            PlayerPrefs.SetInt("Record", _record);
        }

        _record = PlayerPrefs.GetInt("Record", 0);

        _endGamePanel.SetScore(_score, _record);
    }
}
