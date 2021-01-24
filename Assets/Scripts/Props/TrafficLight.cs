using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrafficStatus
{
    StopTraffic, ResumeTraffic
}

public class TrafficLight : MonoBehaviour
{

    #region FIELDS DECLERATION

    public DataManager dataManager;
    public Transform pedestrain;
    public Transform pedestrainPoint;
    public float SignalOnDelay = 5f;
    public GameObject[] trafficLight;
    public bool playerCanPass = true;


    [SerializeField] public TrafficStatus trafficStatus;


    #endregion

    private void Start()
    {
        trafficStatus = TrafficStatus.ResumeTraffic;
        ChangeSignal();
    }

    public void ChangeSignal()
    {
        StartCoroutine(ChangeSignalLights(trafficStatus));
    }

    IEnumerator ChangeSignalLights(TrafficStatus status)
    {
        int index;

        if (status == TrafficStatus.ResumeTraffic)
        {
            index = trafficLight.Length - 1;
        }
        else
        {
            index = 0;
        }

        while (index >= 0 && index <= trafficLight.Length - 1)
        {
            if (status == TrafficStatus.ResumeTraffic)
            {
                for (int i = trafficLight.Length - 1; i >= 0; i--)
                {
                    trafficLight[i].SetActive(i == index);
                }
                index--;
            }
            else
            {
                for (int i = 0; i < trafficLight.Length; i++)
                {
                    trafficLight[i].SetActive(i == index);
                }
                index++;
            }

            yield return new WaitForSeconds(0.5f);
        }

        playerCanPass = (status == TrafficStatus.ResumeTraffic);

        if (!playerCanPass) // Means Signal is Red
        {
            #region ACTIVATE PEDESTRAIN
            if (pedestrain != null)
            {
                pedestrain.position = pedestrainPoint.position;
                pedestrain.rotation = pedestrainPoint.rotation;
                pedestrain.gameObject.SetActive(true);
            }
            #endregion

            yield return new WaitForSeconds(SignalOnDelay);
            trafficStatus = TrafficStatus.ResumeTraffic;
            ChangeSignal();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (!playerCanPass && other.CompareTag("Player"))
        {
            dataManager.RaiseLevelFailEvent("Due to breaking traffic signal");
        }
    }

}
