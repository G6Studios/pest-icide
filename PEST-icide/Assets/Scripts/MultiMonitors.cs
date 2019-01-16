using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is to active multiple monitor display
// It needs to be called once on the scene startup

public class MultiMonitors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Displays connected: " + Display.displays.Length);
        // Display.displays[0] is the default display and is always on
        // Check if there are additional displays and activate them
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
        if (Display.displays.Length > 3)
            Display.displays[3].Activate();
    }

}
