using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{

    #region FIELDS DECLERATION

    public float makeCallMin = 10f;
    public float makeCallMax = 12f;

    public GameObject callPanel;

    #endregion

    private void Start()
    {
        InitiateCall();
    }

    public void InitiateCall()
    {
        float callDuration = Random.Range(makeCallMin, makeCallMax);
        StartCoroutine(MakePhoneCall(callDuration));
    }

    IEnumerator MakePhoneCall(float callDuration)
    {
        while (true)
        {
            yield return new WaitForSeconds(callDuration);
            callPanel.SetActive(true);
        }
    }

}
