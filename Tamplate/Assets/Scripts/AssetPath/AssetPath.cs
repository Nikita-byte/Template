using System.Collections.Generic;


public sealed class AssetsPath
{
    public static readonly Dictionary<ObjectType, string> Path = new Dictionary<ObjectType, string>
        {
            {
                 ObjectType.Camera, "Camera"
            },
            {
                 ObjectType.Canvas, "Canvas"
            },
            {
                 ObjectType.Sprites, "UI"
            },
            {
                ObjectType.MainMenu, "UI/MainMenu"
            },
             {
                ObjectType.GamePanel, "UI/GamePanel"
            },
            {
                ObjectType.SettingsPanel, "UI/Settings"
            },
            {
                ObjectType.EndGamePanel, "UI/EndGamePanel"
            },
            {
                ObjectType.HighScorePanel, "UI/HighScorePanel"
            },
            {
                ObjectType.BackGround, "BackGround"
            },


        };
}