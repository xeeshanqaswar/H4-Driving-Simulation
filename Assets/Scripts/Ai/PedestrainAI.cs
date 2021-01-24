using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PedestrainAI : MonoBehaviour
{
    #region FIELD DECLERATION

    public DataManager dataManager;
    public float moveSpeed = 5f;
    public Spline movementPath;

    #endregion

    private void OnEnable()
    {
        StartCoroutine(TraversePath());
    }

    IEnumerator TraversePath()
    {
        while (true)
        {
            movementPath.followers[0].percentage = Mathf.MoveTowards(movementPath.followers[0].percentage, 1f, moveSpeed * Time.deltaTime);

            if (movementPath.followers[0].percentage == 1)
            {
                HidePerson();
                movementPath.followers[0].percentage = 0;
            }

            yield return null;
        }
    }

    private void HidePerson()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            dataManager.RaiseLevelFailEvent("Due to car accident");
        }
    }

}
