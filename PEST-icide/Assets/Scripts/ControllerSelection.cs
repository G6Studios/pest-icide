using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerSelection : MonoBehaviour
{

    public EventSystem events; // Event system that handles controller input on menus
    public GameObject active; // Currently active UI element

    private bool selected; // Currently selected button on the UI

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player 1 is using their left analog stick and there is no element selected
        if(Input.GetAxis("LeftJoystickY_P1") != 0 && selected == false)
        {
            events.SetSelectedGameObject(active);
            selected = true;
        }

    }

    // When the UI element isn't being shown
    private void OnDisable()
    {
        selected = false;
    }
}
