using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    public DataManager dataManager;

    public TextMeshProUGUI speedDisplay;
    private AudioSource audioSource;
    private float currentSpeed;

    private void OnEnable()
    {
        dataManager.EventLevelFail += GameOverState;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        currentSpeed = Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude * 2.23693629f);
        speedDisplay.text = currentSpeed.ToString("000");

        SpeedLimitCheck();
    }

    public void SpeedLimitCheck()
    {
        float speedLimit = dataManager.levelProps[dataManager.currentLevel].speedLimit;
        if (currentSpeed > speedLimit)
        {
            dataManager.RaiseLevelFailEvent("Due to Crossing the speed limit");
        }
    }

    private void GameOverState(string reason)
    {
        audioSource.enabled = false;
    }

    private void OnDisable()
    {

        dataManager.EventLevelFail -= GameOverState;
    }


}
