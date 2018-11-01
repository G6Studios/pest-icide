using UnityEngine;

public class Frog : MonoBehaviour {
    // Data members
    private float f_resources;
    private float f_speed;
    private float f_jumpHeight;
    private float f_jumpLength;

	// Use this for initialization
	void Start () {
        Resources = 0.0f;
        Speed = 3.0f;
        JumpHeight = 5.0f;
        JumpLength = 5.0f;
	}

    // Setters and getters
    public float Resources
    {
        get { return f_resources; }
        set { f_resources = value; }
    }

    public float Speed
    {
        get { return f_speed; }
        set { f_speed = value; }
    }

    public float JumpHeight
    {
        get { return f_jumpHeight; }
        set { f_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return f_jumpLength; }
        set { f_jumpLength = value; }
    }
	

}
