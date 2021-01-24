using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGuide : MonoBehaviour
{

    bool triggerBuffer;
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NpcVehicle"))
        {
            if (!triggerBuffer)
            {
                triggerBuffer = true;
                boxCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerBuffer)
        {
            triggerBuffer = false;
            boxCollider.isTrigger = false;
        }
    }

}
