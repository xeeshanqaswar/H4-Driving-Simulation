using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public TrafficLight trafficLight;
    public TrafficStatus trafficStatus;

    private bool triggerFlag = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggerFlag)
        {
            triggerFlag = true;
            trafficLight.trafficStatus = trafficStatus;
            trafficLight.ChangeSignal();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && triggerFlag)
        {
            triggerFlag = false;
        }
    }

}
