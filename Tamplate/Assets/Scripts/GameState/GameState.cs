using System.Collections.Generic;
using UnityEngine;


public class GameState : BaseState
{
    private GameController _gameController;
    private List<ITurnOn> _controllers;
    private List<IUpdate> _updateControllers;

    public GameState(GameController gameController)
    {
        _gameController = gameController;
        _controllers = new List<ITurnOn>();
        _updateControllers = new List<IUpdate>();
        EventManager.Instance.AddListener(EventType.StartGame, StartGame);

        //_controllers.Add(new WhellController());
        //_controllers.Add(new BowController());
        //_controllers.Add(new LevelController());

        //_updateControllers.Add(_controllers[0] as IUpdate);
        //_updateControllers.Add(_controllers[1] as IUpdate);

        _controllers.Add(new Counter());
    }

    public override void Enter()
    {
        Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
        Screen.orientation = UnityEngine.ScreenOrientation.Landscape;
        Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;

        ScreenInterface.Instance.Execute(PanelType.GamePanel);

        foreach (ITurnOn controller in _controllers)
        {
            controller.TurnOn();
        }
    }

    public override void Exit()
    {
        foreach (ITurnOn controller in _controllers)
        {
            controller.TurnOff();
        }
    }

    public override void FixedUpdate()
    {
        foreach (IUpdate controller in _updateControllers)
        {
            controller.FixedUpdate();
        }
    }

    public override void LateUpdate()
    {
        foreach (IUpdate controller in _updateControllers)
        {
            controller.LateUpdate();
        }
    }

    public override void Update()
    {
        foreach (IUpdate controller in _updateControllers)
        {
            controller.Update();
        }
    }

    public void StartGame()
    {
        _gameController.SetState(StateCreator.Instance.GameState);
    }
}