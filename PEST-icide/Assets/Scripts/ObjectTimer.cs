using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Raza Kazmi 100592008
//This class is for object timing.
//We can use this to see how long an object has been active or deactive.
//Can expand functionality later if desired, to see the object lifetime.

public class ObjectTimer : MonoBehaviour
{
    private float timeDeactivated;

    private void Start()
    {
        timeDeactivated = 0.0f;  
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
