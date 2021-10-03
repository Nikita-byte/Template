using UnityEngine;
using System.Collections.Generic;


public class GameController : MonoBehaviour
{
    private BaseState _currentGameState;

    private void Awake()
    {
        ObjectPool.Instance.GetObject(ObjectType.Camera).SetActive(true);
        EventManager.Instance.Initialize();
        StateCreator.Instance.SetGameController(this);
        SoundManager.Instance.Sounds["StreetLove"].GetComponent<AudioSource>().Play();

        SetState(StateCreator.Instance.MainMenuState);
    }

    public void SetState(BaseState state)
    {
        if (_currentGameState != null)
        {
            _currentGameState.Exit();
        }

        _currentGameState = state;
        _currentGameState.Enter();
    }

    private void Update()
    {
        _currentGameState.Update();
    }

    private void FixedUpdate()
    {
        _currentGameState.FixedUpdate();
    }

    private void LateUpdate()
    {
        _currentGameState.LateUpdate();
    }
}
