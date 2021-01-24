using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Game Data Manager")]
public class DataManager : ScriptableObject
{

    #region  FIELDS DECLERATION

    [Header("== GAME DATA ==")]
    public int currentLevel;
    public int levelsUnLocked;
    public int maxLevel;
    public LevelProperties[] levelProps;

    #region EVENTS DECLERATION
    public event Action EventLevelComplete;
    public event Action<string> EventLevelFail;
    #endregion

    #endregion


    public void RaiseLevelCompleteEvent()
    {
        EventLevelComplete?.Invoke();
    }

    public void RaiseLevelFailEvent(string reason)
    {
        EventLevelFail?.Invoke(reason);
    }

}

[Serializable]
public class LevelProperties
{
    public string name;
    public float speedLimit;
}