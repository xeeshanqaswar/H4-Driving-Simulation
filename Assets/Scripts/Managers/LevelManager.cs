using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    #region FIELDS DECLERATION

    [Header("== REFERENCES ==")]
    public Transform player;
    public DataManager dataManager;


    [Header("== LEVEL DATA  ==")]
    public LevelTemplate[] levelData;

    public int CurrentLevel
    {
        private set
        {
            dataManager.currentLevel = value;
        }
        get
        {
            return dataManager.currentLevel;
        }
    }

    // Private Variable Decleration =====

    #endregion

    private void OnEnable()
    {
        dataManager.EventLevelComplete += LevelComplete;
    }

    private void Start()
    {
        ChooseLevel();
        SpawnPlayerAtPos(levelData[CurrentLevel].spawnPoint);
    }

    private void ChooseLevel()
    {
        for (int i = 0; i < levelData.Length; i++)
        {
            levelData[i].levelObj.SetActive(i == CurrentLevel);
        }
    }

    /// <summary>
    /// Spawn Player at provided position
    /// </summary>
    public void SpawnPlayerAtPos(Transform spawnPos)
    {
        player.parent = spawnPos;
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.Euler(Vector3.zero);
        player.parent = null;
    }

    private void LevelComplete()
    {
        if (dataManager.levelsUnLocked < dataManager.maxLevel - 1)
        {
            dataManager.levelsUnLocked++;
            dataManager.levelsUnLocked = Mathf.Clamp(dataManager.levelsUnLocked, 0, dataManager.maxLevel);
        }
        else
        {
            UiManager.Instance.gameComplete = true;
        }
    }

    private void OnDisable()
    {
        dataManager.EventLevelComplete -= LevelComplete;
    }

}

[System.Serializable]
public class LevelTemplate
{
    public string name;
    public GameObject levelObj;
    public Transform spawnPoint;
}
