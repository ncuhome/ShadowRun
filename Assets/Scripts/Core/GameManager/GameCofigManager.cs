using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConfigManager
{
    private static GameConfigManager _instance;
    public static GameConfigManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameConfigManager();
            }
            return _instance;
        }
    }

    public GameConfig_SO gameConfig_SO
    {
        get
        {
            if (SceneManager.GetActiveScene().name == SceneEnum.Game.ToString())
            {
                return gameConfig_SO_GameScene;
            }
            else if (SceneManager.GetActiveScene().name == SceneEnum.Novice.ToString())
            {
                return gameConfig_SO_Novice;
            }
            else
            {
                Debug.LogError("GameConfigManager: not found GameConfig_SO");
                return null;
            }              
        }
    }
    public CharacterAction_SO characterAction_SO
    {
        get
        {
            if (SceneManager.GetActiveScene().name == SceneEnum.Game.ToString())
            {
                return characterAction_SO_GameScene;
            }
            else if (SceneManager.GetActiveScene().name == SceneEnum.Novice.ToString())
            {
                return characterAction_SO_Novice;
            }
            else
            {
                Debug.LogError("GameConfigManager: not found CharacterAction_SO");
                return null;
            }
        }
    }
    public GameLevelPreset_SO gameLevelPreset_SO
    {
        get
        {
            if (SceneManager.GetActiveScene().name == SceneEnum.Game.ToString())
            {
                return gameLevelPreset_SO_GameScene;
            }
            else
            {
                Debug.LogError("GameConfigManager: not found GameLevelPreset_SO");
                return null;
            }
        }
    }

    private GameConfig_SO gameConfig_SO_GameScene;
    private GameConfig_SO gameConfig_SO_Novice;
    private CharacterAction_SO characterAction_SO_GameScene;
    private CharacterAction_SO characterAction_SO_Novice;
    private GameLevelPreset_SO gameLevelPreset_SO_GameScene;

    private GameConfigManager()
    {
        //gameScene
        gameConfig_SO_GameScene = Resources.Load<GameConfig_SO>("GameScene/GameConfig_SO");
        characterAction_SO_GameScene = Resources.Load<CharacterAction_SO>("GameScene/CharacterAction_SO");
        gameLevelPreset_SO_GameScene = Resources.Load<GameLevelPreset_SO>("GameScene/GameLevelPreset_SO");

        //novice
        gameConfig_SO_Novice = Resources.Load<GameConfig_SO>("Novice/GameConfig_SO");
        characterAction_SO_Novice = Resources.Load<CharacterAction_SO>("Novice/CharacterAction_SO");
    }
}