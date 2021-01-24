using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class AIBehaviour : MonoBehaviour
{

    public int pathIndex = 0;
    public float moveSpeed = 5f;
    public Spline movementPath;
    public bool pause = false;
    public bool loop = false;

    private bool triggerBuffer;

    private void Start()
    {
        StartCoroutine(TraversePath());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!triggerBuffer)
            {
                triggerBuffer = !triggerBuffer;
                pause = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerBuffer)
        {
            triggerBuffer = !triggerBuffer;
            pause = false;
        }
    }

    IEnumerator TraversePath()
    {
        while (true)
        {
            if (!pause)
            {
                movementPath.followers[pathIndex].percentage = Mathf.MoveTowards(movementPath.followers[pathIndex].percentage, 1f, moveSpeed * Time.deltaTime);
                if (loop)
                {
                    movementPath.followers[pathIndex].percentage = movementPath.followers[pathIndex].percentage % 1f;
                }
            }

            yield return null;
        }
    }


}
