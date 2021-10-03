using UnityEngine;


public class MainMenuState : BaseState
{
    private GameController _gameController;

    public MainMenuState(GameController gameController)
    {
        _gameController = gameController;
        EventManager.Instance.AddListener(EventType.MainMenu, MainMenu);
    }

    public override void Enter()
    {
        Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;


        ScreenInterface.Instance.Execute(PanelType.MainMenu);
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void LateUpdate()
    {

    }

    public override void Update()
    {

    }

    public void MainMenu()
    {
        _gameController.SetState(StateCreator.Instance.MainMenuState);
    }
}
