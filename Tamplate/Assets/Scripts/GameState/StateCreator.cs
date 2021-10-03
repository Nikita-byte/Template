


public class StateCreator
{
    public static readonly StateCreator Instance = new StateCreator();

    public MainMenuState MainMenuState;
    public EndGameState EndGameState;
    public GameState GameState;

    public void SetGameController(GameController gameController)
    {
        MainMenuState = new MainMenuState(gameController);
        EndGameState = new EndGameState(gameController);
        GameState = new GameState(gameController);
    }
}
