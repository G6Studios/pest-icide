using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Raza Kazmi 100592008
//This class is for object time stamping.
//We can use this to see how long an object has been active or deactive, and when it was created.
//We are using time stamps instead of an actual "Timer" for performance reasons
//This way every object wont have to do calculations every frame to update the timer for it.
//Can expand functionality later to do more timing if desired
public class ObjectTimer : MonoBehaviour
{
    private float timeCreated;
    private float timeActivated;
    private float timeDeactivated;

    private void Start()
    {
        timeCreated = Time.time;
        timeActivated = 0.0f;
        timeDeactivated = 0.0f;  
        
    }

    public float GetTimeCreated()
    {
        return timeCreated;
    }

    public float GetTimeActivated()
    {
        return timeActivated;
    }

    public void SetTimeActivated()
    {
        timeActivated = Time.time;
    }

    public void ResetActivatedTime()
    {
        timeActivated = 0.0f;
    }

    public float GetDeactivatedTime()
    {
        return timeDeactivated;
    }

    public void SetDeactivatedTime()
    {
        timeDeactivated = Time.time;
    }

    public void ResetDeactiveTime()
    {
        timeDeactivated = 0.0f;
    }


}
