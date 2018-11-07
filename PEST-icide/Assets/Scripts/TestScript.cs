using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // For events
    private UnityAction testListener;

    // These two functions ensure memory leaks do not occur
    public void OnEnable()
    {
        EventManager.instance.StartListening("test", testListener);
    }

    public void OnDisable()
    {
        EventManager.instance.StopListening("test", testListener);
    }

    void Awake()
    {
        testListener = new UnityAction(testFunction);
    }

    void testFunction()
    {
        Debug.Log("It works!");
    }
}
