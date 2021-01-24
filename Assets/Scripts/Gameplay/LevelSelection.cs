using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    #region FIELDS DECLERATION

    public DataManager dataManager;
    public Button[] levelsList;

    #endregion

    private void Start()
    {
        UpdateLevels();
    }

    private void UpdateLevels()
    {
        for (int i = 0; i < levelsList.Length; i++)
        {
            levelsList[i].interactable = i <= dataManager.levelsUnLocked;
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(int a)
    {
        dataManager.currentLevel = a;
        ChangeScene("Gameplay");
    }

}
