using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 joyLook; //joystick camera look
    Vector2 joySmooth; //smoothing for joystick
    Vector2 smoothV;
    public float sensitivity = 3.0f; // Variable to control sensitivity
    public float smoothing = 2.0f; // Variable to control degree of mouse smoothing
    public int joystickNumber;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        string joystickString = joystickNumber.ToString();

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        var jd = new Vector2(Input.GetAxis("RightJoystickX_P" + joystickString), Input.GetAxis("RightJoystickY_P" + joystickString)); //right joystick direction for each controller

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        jd = Vector2.Scale(jd, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        joySmooth.x = Mathf.Lerp(joySmooth.x, jd.x, 1f / smoothing);
        joySmooth.y = Mathf.Lerp(joySmooth.y, jd.y, 1f / smoothing);

        // Updating the mouselook vector
        mouseLook += smoothV;
        joyLook += joySmooth;

        // This ensures that the player cannot flip the camera upside-down by looking too far forward or back
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        joyLook.y = Mathf.Clamp(joyLook.y, -90f, 90f);


        if (Input.GetJoystickNames().Length <= 0)
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-joyLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(joyLook.x, character.transform.up);
        }

        
        

    }
}
