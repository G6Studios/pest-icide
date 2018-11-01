using UnityEngine;

public class Spider : MonoBehaviour {
    // Data members
    private float sp_resources;
    private float sp_speed;
    private float sp_jumpHeight;
    private float sp_jumpLength;


	// Use this for initialization
	void Start ()
    {
        Resources = 0.0f;
        Speed = 10.0f;
        JumpHeight = 1.5f;
        JumpLength = 1.5f;
	}

    // Getters and setters
    public float Resources
    {
        get { return sp_resources; }
        set { sp_resources = value; }
    }

    public float Speed
    {
        get { return sp_speed; }
        set { sp_speed = value; }
    }

    public float JumpHeight
    {
        get { return sp_jumpHeight; }
        set { sp_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return sp_jumpLength; }
        set { sp_jumpLength = value; }
    }
	
}
