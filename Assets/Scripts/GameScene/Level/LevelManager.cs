using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameConfig_SO gameConfig_SO;
    private CharacterAction_SO characterAction_SO;
    private GameLevelPreset_SO gameLevelPreset_SO;
    private GameLevelPreset_SO.LevelData currentLevelData;
    private GameLevelPreset_SO.LevelData nextLevelData;
    private int nextLevelDataIndex = 0;
    private bool isMaxLevel = false;
    void Awake()
    {
        gameConfig_SO = GameConfigManager.instance.gameConfig_SO;
        characterAction_SO = GameConfigManager.instance.characterAction_SO;;  
        gameLevelPreset_SO = GameConfigManager.instance.gameLevelPreset_SO;
        currentLevelData = gameLevelPreset_SO.defualtLevelData;
        nextLevelData = gameLevelPreset_SO.levelDatas[nextLevelDataIndex];
        UpdateLeveData();
    }
    void FixedUpdate()
    {
        if(IsLevelComplete())
        {
            ChangeLevel();
        }
    }
    bool IsLevelComplete()
    {
        if(isMaxLevel) return false;
        if (nextLevelData.trigglerScore <= ScoreManager.instance.score)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    void ChangeLevel()
    {              
        nextLevelDataIndex++;
        if (nextLevelDataIndex >= gameLevelPreset_SO.levelDatas.Length)
        {
            isMaxLevel = true;
            return;
        }
        currentLevelData = nextLevelData;  
        nextLevelData = gameLevelPreset_SO.levelDatas[nextLevelDataIndex];
        
        UpdateLeveData();
        Debug.Log("LevelManager: " + currentLevelData.levelName);
    }
    /// <summary>
    /// 更新难度数据
    /// </summary>
    public void UpdateLeveData()
    {
        //更新难度
        gameConfig_SO.darkSpeed = currentLevelData.darkSpeed;
        gameConfig_SO.blackChaseSpeed = currentLevelData.blackChaseSpeed;
        gameConfig_SO.minLight= currentLevelData.minLight;
        gameConfig_SO.deadDistance= currentLevelData.deadDistance;
        characterAction_SO.moveForwardSpeed = currentLevelData.moveForwardSpeed;
        characterAction_SO.moveBackSpeed = currentLevelData.moveBackSpeed;
        characterAction_SO.fixSpeed = currentLevelData.fixSpeed;
        characterAction_SO.jumpMaxTime = currentLevelData.jumpMaxTime;
        characterAction_SO.jumpHeight = currentLevelData.jumpHeight;
    }

}
