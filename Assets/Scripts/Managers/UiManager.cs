using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    #region FIELDS DECLERATION

    public DataManager dataManager;
    public TextMeshProUGUI failReason;
    public GameObject[] dialogueBoxes;
    public bool gameComplete = false;

    [Header("PHONE CALL FEATURE")]
    public GameObject callPanel;

    // READ ONLY FIELDS
    private PhoneCall phoneCall;
    private static UiManager instance;
    public static UiManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    #endregion

    private void OnEnable()
    {
        dataManager.EventLevelComplete += LevelComplete;
        dataManager.EventLevelFail += LevelFail;
    }

    private void Start()
    {
        Instance = this;
        Time.timeScale = 1;
        phoneCall = GetComponent<PhoneCall>();
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void OpenDialogue(int a)
    {
        Time.timeScale = 0.0001f;
        for (int i = 0; i < dialogueBoxes.Length; i++)
        {
            dialogueBoxes[i].SetActive(i == a);
        }
    }

    public void CloseAllDialogue()
    {
        OpenDialogue(-1);
        Time.timeScale = 1;
    }

    #region PHONE CALL FEATURE

    public void AcceptPhoneCall()
    {
        dataManager.RaiseLevelFailEvent("Due to disobeying the traffic laws");
    }

    public void DeclinePhoneCall()
    {
        callPanel.SetActive(false);
        phoneCall.InitiateCall();
    }

    #endregion


    private void LevelComplete()
    {
        if (gameComplete)
        {
            OpenDialogue(2);
        }
        else
        {
            OpenDialogue(1);
        }
    }

    private void LevelFail(string reason)
    {
        failReason.text = reason;
        OpenDialogue(0);
    }


    private void OnDisable()
    {
        dataManager.EventLevelComplete -= LevelComplete;
        dataManager.EventLevelFail -= LevelFail;
    }

}
