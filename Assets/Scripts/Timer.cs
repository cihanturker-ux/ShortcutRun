using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Update is called once per frame
    private float timeRemaining;

    void Update()
    {
        if (timeRemaining > 0.2)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void setTime(float time)
    {
        timeRemaining=time;
    }
    public float getTime()
    {
        return timeRemaining;
    }
}
