using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteZone : MonoBehaviour
{

    public DataManager dataManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Invoke("LevelComplete", 2f);
        }
    }

    private void LevelComplete()
    {
        dataManager.RaiseLevelCompleteEvent();
    }
}
